using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.GUI;
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
        public Point3D OldLocation { get; private set; }

        [ProtoMember(3)]
        public Point3D NewLocation { get; private set; }

        public LivingLocationModifier(Guid entityID, Point3D oldLocation, Point3D newLocation)
        {
            this.EntityID = entityID;
            this.OldLocation = oldLocation;
            this.NewLocation = newLocation;
        }

        protected LivingLocationModifier()
        {
            //Protobuf-net constructor
        }

        public override void ModifyWorld()
        {
            Chunk oldChunk = MagicalLifeAPI.World.Data.World.GetChunkByTile(this.OldLocation.DimensionID, this.OldLocation.X, this.OldLocation.Y);
            Chunk newChunk = MagicalLifeAPI.World.Data.World.GetChunkByTile(this.NewLocation.DimensionID, this.NewLocation.X, this.NewLocation.Y);
            Living l = oldChunk.Creatures[this.EntityID];

            l.GetExactComponent<ComponentSelectable>().MapLocation = this.NewLocation;
            oldChunk.Creatures.Remove(this.EntityID);
            newChunk.Creatures.Add(this.EntityID, l);
        }
    }
}