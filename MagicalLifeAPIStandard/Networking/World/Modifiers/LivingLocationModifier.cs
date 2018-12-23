using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Data;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Networking.World.Modifiers
{
    /// <summary>
    /// Used to update the location of an entity.
    /// </summary>
    [ProtoContract]
    public class LivingLocationModifier : AbstractWorldModifier
    {
        [ProtoMember(1)]
        public Guid EntityID { get; private set; }

        [ProtoMember(2)]
        public Point2D OldLocation { get; private set; }

        [ProtoMember(3)]
        public Point2D NewLocation { get; private set; }

        [ProtoMember(4)]
        public int Dimension { get; private set; }

        public LivingLocationModifier(Guid entityID, Point2D oldLocation, Point2D newLocation, int dimension)
        {
            this.EntityID = entityID;
            this.OldLocation = oldLocation;
            this.NewLocation = newLocation;
            this.Dimension = dimension;
        }

        protected LivingLocationModifier()
        {
            //Protobuf-net constructor
        }

        public override void ModifyWorld()
        {
            Chunk oldChunk = MagicalLifeAPI.World.Data.World.GetChunkByTile(this.Dimension, this.OldLocation.X, this.OldLocation.Y);
            Chunk newChunk = MagicalLifeAPI.World.Data.World.GetChunkByTile(this.Dimension, this.NewLocation.X, this.NewLocation.Y);
            Living l = oldChunk.Creatures[this.EntityID];

            l.MapLocation = this.NewLocation;
            oldChunk.Creatures.Remove(this.EntityID);
            newChunk.Creatures.Add(this.EntityID, l);
        }
    }
}