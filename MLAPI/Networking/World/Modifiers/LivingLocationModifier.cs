using System;
using MLAPI.Components;
using MLAPI.Components.Entity;
using MLAPI.DataTypes;
using MLAPI.Entity;
using MLAPI.World.Data;
using ProtoBuf;

namespace MLAPI.Networking.World.Modifiers
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
            Chunk oldChunk = MLAPI.World.Data.World.GetChunkByTile(this.OldLocation.DimensionID, this.OldLocation.X, this.OldLocation.Y);
            Chunk newChunk = MLAPI.World.Data.World.GetChunkByTile(this.NewLocation.DimensionID, this.NewLocation.X, this.NewLocation.Y);
            Living l = oldChunk.Creatures[this.EntityID];
            ComponentSelectable selectable = l.GetExactComponent<ComponentSelectable>();
            ComponentMovement movement = l.GetExactComponent<ComponentMovement>();

            movement.TileLocation = new Point2DDouble(this.NewLocation.X, this.NewLocation.Y);
            selectable.MapLocation = this.NewLocation;
            oldChunk.Creatures.Remove(this.EntityID);
            newChunk.Creatures.Add(this.EntityID, l);
        }
    }
}