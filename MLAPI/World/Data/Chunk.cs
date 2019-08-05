using System;
using System.Collections.Generic;
using System.Linq;
using MLAPI.Components;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Collection;
using MLAPI.Entity;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLAPI.World.Data
{
    /// <summary>
    /// Holds a section of the world.
    /// </summary>
    [ProtoContract]
    public class Chunk
    {
        [ProtoMember(1)]
        public Dictionary<Guid, Living> Creatures;

        [ProtoMember(2)]
        public ProtoArray<Tile> Tiles;

        [ProtoMember(3)]
        public Point2D ChunkLocation;

        /// <summary>
        /// The items within this chunk.
        /// </summary>
        [ProtoMember(5)]
        public Dictionary<int, RTree<Point2D>> Items = new Dictionary<int, RTree<Point2D>>();

        [ProtoMember(6)]
        public Guid ID { get; }

        /// <summary>
        /// The width of this chunk in tiles.
        /// </summary>
        public static readonly int Width = 15;

        /// <summary>
        /// The height of this chunk in tiles.
        /// </summary>
        public static readonly int Height = 15;

        public Chunk(Dictionary<Guid, Living> creatures, ProtoArray<Tile> tiles, Point2D location)
        {
            this.ID = Guid.NewGuid();
            this.Creatures = creatures;
            this.Tiles = tiles;
            this.ChunkLocation = location;
            this.Items = new Dictionary<int, RTree<Point2D>>();
        }

        public Chunk()
        {
            //Protobuf - net constructor
        }

        [ProtoAfterDeserialization]
        private void AfterDeserialization()
        {
            if (this.Creatures == null)
            {
                this.Creatures = new Dictionary<Guid, Living>();
            }

            if (this.Items == null)
            {
                this.Items = new Dictionary<int, RTree<Point2D>>();
            }
        }

        /// <summary>
        /// Returns the creature in the specified location.
        /// The overload of this method fetching based upon a <see cref="Guid"/> should be preferred over this, as it has faster performance in highly populated chunks.
        /// </summary>
        /// <param name="Point2D">The location to search.</param>
        /// <param name="living"></param>
        /// <returns>Returns whether or not a creature was found in the specified location.</returns>
        public bool GetCreature(Point2D Point2D, out Living living)
        {
            living = null;
            IEnumerable<KeyValuePair<Guid, Living>> result =
                this.Creatures.Where(x => Point2D.Equals(x.Value.GetExactComponent<ComponentSelectable>().MapLocation));

            if (result.Any())
            {
                living = result.ElementAt(0).Value;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// The fastest way of getting a creature.
        /// </summary>
        /// <param name="creatureID"></param>
        /// <param name="living"></param>
        /// <returns></returns>
        public bool GetCreature(Guid creatureID, out Living living)
        {
            return this.Creatures.TryGetValue(creatureID, out living);
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            foreach (Tile item in this.Tiles)
            {
                yield return item;
            }
        }
    }
}