using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.World.Items;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// Stone as a resource.
    /// </summary>
    [ProtoContract]
    public class Stone : StoneBase
    {
        public override AbstractMinable MiningBehavior { get; set; }

        public Stone(int durability) : base("Stone", durability)
        {
            this.MiningBehavior = new DropWhenCompletelyMined(new List<Base.Item>()
            {
                new StoneChunk(this.Durability)
            });
        }

        public Stone() : base()
        {
        }

        public override string GetUnconnectedTexture()
        {
            return "Stone";
        }
    }
}