using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Data;
using ProtoBuf;

namespace MagicalLifeAPI.Networking.World.Modifiers
{
    /// <summary>
    /// Used to spawn a creature in the world in a multiplayer game.
    /// </summary>
    [ProtoContract]
    public class LivingCreatedModifier : AbstractWorldModifier
    {
        [ProtoMember(1)]
        public Living Living { get; private set; }

        public LivingCreatedModifier(Living living)
        {
            this.Living = living;
        }

        public LivingCreatedModifier()
        {
            //Protobuf-net constructor.
        }

        public override void ModifyWorld()
        {
            Chunk chunk = MagicalLifeAPI.World.Data.World.GetChunkByTile(this.Living.Dimension, this.Living.MapLocation.X, this.Living.MapLocation.Y);
            chunk.Creatures.Add(this.Living.ID, this.Living);
        }
    }
}