using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.World.Tiles;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Base
{
    /// <summary>
    /// Every tile that implements this class must provide a parameterless version of itself for reflection purposes. That constructor will not be used during gameplay.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(9, typeof(Dirt))]
    [ProtoInclude(10, typeof(Grass))]
    public abstract class Tile : Selectable, IHasSubclasses, IRenderContainer
    {
        [ProtoMember(2)]
        public bool IsWalkable;

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

        [ProtoMember(4)]
        private Resource resources;

        /// <summary>
        /// The resources that can be found in this tile.
        /// </summary>
        public Resource Resources
        {
            get
            {
                return this.resources;
            }

            set
            {
                if (this.resources == null)
                {
                    this.resources = value;

                    if (value != null)
                    {
                        this.CompositeRenderer.AddVisuals(value.GetVisuals());
                    }

                    return;
                }

                List<AbstractVisual> oldVisuals = this.resources.GetVisuals();

                if (value == null)
                {
                    this.RemoveVisual(oldVisuals);
                }
                else
                {
                    List<AbstractVisual> newVisuals = value.GetVisuals();

                    if (this.IsVisualDifferent(oldVisuals, newVisuals))
                    {
                        this.RemoveVisual(oldVisuals);
                    }
                    this.CompositeRenderer.AddVisuals(newVisuals);
                }

                this.resources = value;
            }
        }

        //public List<Vegetation> Plants { get; set; } = new List<Vegetation>();

        /// <summary>
        /// The item(s) that is stored in this tile.
        /// </summary>
        [ProtoMember(6)]
        public Item Item { get; set; }

        [ProtoMember(7)]
        public ActionSelected ImpendingAction { get; set; }

        [ProtoMember(8)]
        public abstract ComponentRenderer CompositeRenderer { get; set; }

        public readonly int FootStepSound;

        /// <summary>
        /// Initializes a new tile object.
        /// </summary>
        /// <param name="location">The 3D location of this tile in the map.</param>
        /// <param name="movementCost">This value is the movement cost of walking on this tile. It should be between 1 and 100</param>
        protected Tile(Point2D location, int movementCost, int footStepSound)
        {
            this.MapLocation = location;
            this.MovementCost = movementCost;
            Tile.TileCreatedHandler(new TileEventArg(this));
            this.IsWalkable = true;
            this.FootStepSound = footStepSound;
        }

        protected Tile(int x, int y, int movementCost, int footStepSound)
            : this(new Point2D(x, y), movementCost, footStepSound)
        {
        }

        /// <summary>
        /// This constructor is used during loading/reflection only.
        /// </summary>
        public Tile()
        {
        }

        /// <summary>
        /// Raised whenever a tile is created after the world is finished generating for the first time.
        /// </summary>
        public static event EventHandler<TileEventArg> TileCreated;

        /// <summary>
        /// Raised whenever this specific tile is modified.
        /// </summary>
        public event EventHandler<TileEventArg> TileModified;

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        public static void TileCreatedHandler(TileEventArg e)
        {
            TileCreated?.Invoke(e, e);
        }

        public void TileModifiedHandler(TileEventArg e)
        {
            TileModified?.Invoke(this, e);
        }

        private void RemoveVisual(List<AbstractVisual> visuals)
        {
            foreach (AbstractVisual item in visuals)
            {
                this.CompositeRenderer.RenderQueue.Remove(item);
            }
        }

        public Dictionary<Type, int> GetSubclassInformation()
        {
            Dictionary<Type, int> ret = new Dictionary<Type, int>
            {
                { typeof(Dirt), 7 },
                { typeof(Grass), 8 }
            };

            return ret;
        }

        public Type GetBaseType()
        {
            return typeof(Tile);
        }

        /// <summary>
        /// Returns the name of this tile.
        /// </summary>
        /// <returns></returns>
        public abstract string GetName();

        public override SelectionType InGameObjectType(Selectable selectable)
        {
            return SelectionType.Tile;
        }

        private bool IsVisualDifferent(List<AbstractVisual> visual, List<AbstractVisual> visual2)
        {
            if (visual.Count != visual2.Count)
            {
                return true;
            }

            for (int i = 0; i < visual.Count; i++)
            {
                if (!visual[i].Equals(visual2))
                {
                    return true;
                }
            }

            return false;
        }
    }
}