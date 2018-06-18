using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.World.Tiles;
using Microsoft.Xna.Framework;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// Every tile that implements this class must provide a parameterless version of itself for reflection purposes. That constructor will not be used during gameplay.
    /// </summary>
    [ProtoContract]
    public abstract class Tile : HasTexture, IHasSubclasses
    {
        /// <summary>
        /// Initializes a new tile object.
        /// </summary>
        /// <param name="location">The 3D location of this tile in the map.</param>
        /// <param name="movementCost">This value is the movement cost of walking on this tile. It should be between 1 and 100</param>
        public Tile(Point location, int movementCost)
        {
            this.Location = location;
            this.MovementCost = movementCost;
            Tile.TileCreatedHandler(new TileEventArg(this));
            this.TextureIndex = AssetManager.GetTextureIndex(this.GetTextureName());
        }

        public Tile(int x, int y, int movementCost) : this(new Point(x, y), movementCost)
        {
        }

        /// <summary>
        /// This constructor is used during loading/reflection only.
        /// </summary>
        public Tile()
        {
        }

        [ProtoMember(2)]
        public bool isWalkable = true;

        /// <summary>
        /// If true, then the tile can be walked on by living.
        /// </summary>
        public bool IsWalkable
        {
            get
            {
                return this.isWalkable;
            }

            set
            {
                if (value)
                {
                    //Pathfinding.MainPathFinder.PFinder.AddConnections(this.Location);
                }
                else
                {
                    //Pathfinding.MainPathFinder.PFinder.RemoveConnections(this.Location);
                }

                this.isWalkable = value;
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
        public static Microsoft.Xna.Framework.Point GetTileSize()
        {
            return new Microsoft.Xna.Framework.Point(64, 64);
        }

        /// <summary>
        /// Returns the name of this tile.
        /// </summary>
        /// <returns></returns>
        public abstract string GetName();

        /// <summary>
        /// The resources that can be found in this tile.
        /// </summary>
        [ProtoMember(4)]
        public Resource Resources { get; set; }

        //public List<Vegetation> Plants { get; set; } = new List<Vegetation>();

        /// <summary>
        /// The location of this tile in the tile map.
        /// </summary>
        [ProtoMember(5)]
        public Point Location { get; set; }

        /// <summary>
        /// The entity that is in this tile. Is null if there is not an entity in this tile.
        /// </summary>
        [ProtoMember(6)]
        public Living Living { get; set; } = null;

        /// <summary>
        /// Raised when the world is finished generating for the first time.
        /// </summary>
        public static event EventHandler<TileEventArg> TileCreated;

        /// <summary>
        /// Raised whenever this specific tile is modified.
        /// </summary>
        public event EventHandler<TileEventArg> TileModified; //have this be used by the stone stuff so it can determine when to change what texture it is using.

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        public static void TileCreatedHandler(TileEventArg e)
        {
            EventHandler<TileEventArg> handler = TileCreated;
            if (handler != null)
            {
                handler(e, e);
            }
        }

        public void TileModifiedHandler(TileEventArg e)
        {
            EventHandler<TileEventArg> handler = TileModified;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public abstract string GetTextureName();

        public Dictionary<Type, int> GetSubclassInformation()
        {
            Dictionary<Type, int> ret = new Dictionary<Type, int>();
            ret.Add(typeof(Dirt), 1);

            return ret;
        }

        public Type GetBaseType()
        {
            return typeof(Tile);
        }
    }
}