using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Tile.Renderable;
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
    [ProtoInclude(8, typeof(Dirt))]
    [ProtoInclude(9, typeof(Grass))]
    public abstract class Tile : Selectable, IHasSubclasses, IRenderable
    {
        [ProtoMember(1)]
        private ComponentRenderer Renderable { get; set; }

        [ProtoMember(2)]
        public bool IsWalkable;
        private TransitionTextures transitionTextures;

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

        /// <summary>
        /// The resources that can be found in this tile.
        /// </summary>
        [ProtoMember(4)]
        public Resource Resources { get; set; }

        //public List<Vegetation> Plants { get; set; } = new List<Vegetation>();

        /// <summary>
        /// The item(s) that is stored in this tile.
        /// </summary>
        [ProtoMember(6)]
        public Item Item { get; set; }

        [ProtoMember(7)]
        public ActionSelected ImpendingAction { get; set; }
        public abstract ComponentRenderer CompositeRenderer { get; set; }

        public readonly int FootStepSound;

        /// <summary>
        /// Initializes a new tile object.
        /// </summary>
        /// <param name="location">The 3D location of this tile in the map.</param>
        /// <param name="movementCost">This value is the movement cost of walking on this tile. It should be between 1 and 100</param>
        public Tile(Point2D location, int movementCost, ComponentRenderer renderable, int footStepSound)
        {
            this.MapLocation = location;
            this.MovementCost = movementCost;
            Tile.TileCreatedHandler(new TileEventArg(this));
            this.IsWalkable = true;
            this.Renderable = renderable;
            this.FootStepSound = footStepSound;
        }

        public Tile(int x, int y, int movementCost, ComponentRenderer renderable, int footStepSound)
            : this(new Point2D(x, y), movementCost, renderable, footStepSound)
        {
        }

        public object GetRenderable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This constructor is used during loading/reflection only.
        /// </summary>
        public Tile()
        {
        }

        protected Tile(Point2D location, TransitionTextures transitionTextures)
        {
            this.transitionTextures = transitionTextures;
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
    }
}