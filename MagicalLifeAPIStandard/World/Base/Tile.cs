using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Pathfinding;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Base
{
    /// <summary>
    /// Every tile that implements this class must provide a parameterless version of itself for reflection purposes. That constructor will not be used during gameplay.
    /// </summary>
    [ProtoContract]
    public abstract class Tile : HasComponents
    {
        private bool _isWalkable { get; set; }

        [ProtoMember(2)]
        public bool IsWalkable
        {
            get
            {
                return this._isWalkable;
            }
            set
            {
                this._isWalkable = value;
                if (this.ComponentCount() > 0)
                {
                    ComponentSelectable location = this.GetExactComponent<ComponentSelectable>();
                    if (this._isWalkable)
                    {
                        MainPathFinder.UnBlock(location.MapLocation);
                    }
                    else
                    {
                        MainPathFinder.Block(location.MapLocation);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the name of the biome that this tile belongs to.
        /// </summary>
        public string BiomeName { get; }

        /// <summary>
        /// Returns the movement cost of this tile.
        /// Should be between 1-100.
        /// </summary>
        [ProtoMember(3)]
        public int MovementCost { get; set; }

        /// <summary>
        /// The size, in pixels of how big each tile is.
        /// </summary>
        /// <returns></returns>
        public static Point2D GetTileSize()
        {
            return new Point2D(64, 64);
        }

        [ProtoMember(6)]
        private GameObject TileMainObject { get; set; }
        
        /// <summary>
        /// The main object occupying this tile. Is null if there is no object here.
        /// </summary>
        public GameObject MainObject
        {
            get
            {
                return this.TileMainObject;
            }
            set
            {
                this.SetMainObject(value);
            }
        }


        [ProtoMember(7)]
        private GameObject TileFloor { get; set; }

        /// <summary>
        /// The flooring of this tile.
        /// </summary>
        public GameObject Floor
        {
            get
            {
                return this.TileFloor;
            }

            set
            {
                this.SetFloor(value);
            }
        }

        [ProtoMember(8)]
        private GameObject TileCeiling { get; set; }

        public GameObject Ceiling
        {
            get
            {
                return this.TileCeiling;
            }
            set
            {
                this.SetCeiling(value);
            }
        }

        [ProtoMember(9)]
        public ActionSelected ImpendingAction { get; set; }

        /// <summary>
        /// If true this tile has been revealed to the player.
        /// </summary>
        [ProtoMember(10)]
        public bool IsVisible { get; set; } = true;

        public readonly int FootStepSound;

        /// <summary>
        /// Raised whenever a tile is created after the world is finished generating for the first time.
        /// </summary>
        public static event EventHandler<TileEventArgs> TileCreated;

        /// <summary>
        /// Raised whenever this specific tile is modified.
        /// </summary>
        public event EventHandler<TileEventArgs> TileModified;

        /// <summary>
        /// Initializes a new tile object.
        /// </summary>
        /// <param name="location">The 3D location of this tile in the map.</param>
        /// <param name="movementCost">This value is the movement cost of walking on this tile. It should be between 1 and 100</param>
        protected Tile(Point3D location, int movementCost, int footStepSound)
            : base(true)
        {
            ComponentSelectable selectable = new ComponentSelectable(SelectionType.Tile);
            selectable.MapLocation = location;

            this.AddComponent(selectable);
            this.AddComponent(new ComponentRenderer());

            this.IsWalkable = true;
            this.MovementCost = movementCost;
            Tile.TileCreatedHandler(new TileEventArgs(this));
            this.FootStepSound = footStepSound;
        }

        protected Tile(int x, int y, Guid dimensionID, int movementCost, int footStepSound)
            : this(new Point3D(x, y, dimensionID), movementCost, footStepSound)
        {
        }

        /// <summary>
        /// This constructor is used during loading/reflection only.
        /// </summary>
        protected Tile()
        {
        }

        /// <summary>
        /// Returns the name of this tile.
        /// </summary>
        /// <returns></returns>
        public abstract string GetName();

        /// <summary>
        /// Swaps the old visuals with the new.
        /// Can handle null inputs.
        /// </summary>
        /// <param name="oldVisual">Should have a <see cref="ComponentHasTexture"/> component.</param>
        /// <param name="newVisual">Should have a <see cref="ComponentHasTexture"/> component.</param>
        private void UpdateVisuals(HasComponents oldVisual, HasComponents newVisual)
        {
            ComponentRenderer renderComponent = this.GetExactComponent<ComponentRenderer>();

            if (oldVisual != null)
            {
                //Remove old visuals
                ComponentHasTexture oldTextureComponent = oldVisual.GetExactComponent<ComponentHasTexture>();
                renderComponent.RemoveVisuals(oldTextureComponent.Visuals);
            }

            if (newVisual != null)
            {
                //Add new visuals
                ComponentHasTexture newTextureComponent = newVisual.GetExactComponent<ComponentHasTexture>();
                renderComponent.AddVisuals(newTextureComponent.Visuals);
            }
        }

        /// <summary>
        /// Sets the main object of this tile.
        /// </summary>
        /// <param name="mainObject"></param>
        private void SetMainObject(GameObject mainObject)
        {
            this.UpdateVisuals(this.MainObject, mainObject);
            this.TileMainObject = mainObject;
            this.UpdateWalkability();
        }

        /// <summary>
        /// Sets the floor after updating the walkability of this tile and the visuals of this tile.
        /// </summary>
        private void SetFloor(GameObject floor)
        {
            this.UpdateVisuals(this.Floor, floor);
            this.TileFloor = floor;
            this.UpdateWalkability();
        }

        /// <summary>
        /// Sets the ceiling after updating the walkability of this tile and the visuals of this tile.
        /// </summary>
        private void SetCeiling(GameObject ceiling)
        {
            this.UpdateVisuals(this.Ceiling, ceiling);
            this.TileCeiling = ceiling;
            this.UpdateWalkability();
        }

        /// <summary>
        /// Updates the walkability of this tile.
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private void UpdateWalkability()
        {
            //Gather the walkability of all components of this tile.
            bool floor = this.Floor  == null || (this.Floor != null && this.Floor.IsWalkable());
            bool ceiling = this.Ceiling == null || (this.Ceiling != null && this.Ceiling.IsWalkable());
            bool mainObject = this.MainObject == null || (this.MainObject != null && this.MainObject.IsWalkable());

            //Determine if the tile is walkable or not.
            bool composite = floor && ceiling && mainObject;

            //Determine if the tile walkability state needs to change
            if ((composite && !this.IsWalkable) || (!composite && this.IsWalkable))
            {
                this.IsWalkable = composite;
            }
        }

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        public static void TileCreatedHandler(TileEventArgs e)
        {
            TileCreated?.Invoke(e, e);
        }

        public void TileModifiedHandler(TileEventArgs e)
        {
            TileModified?.Invoke(this, e);
        }
    }
}