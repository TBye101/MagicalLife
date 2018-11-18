using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.Util;
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
        public static readonly string StoneName = "Stone";

        public override AbstractMinable MiningBehavior { get; set; }

        public Stone(int durability) : base(StoneName, durability)
        {
            this.MiningBehavior = new DropWhenCompletelyMined(new List<Base.Item>()
            {
                new StoneRubble(this.Durability)
            });
        }

        public Stone() : base()
        {
        }

        public override string GetUnconnectedTexture()
        {
            return TextureLoader.TextureStone1;
        }

        public override List<AbstractVisual> GetVisuals()
        {
            List<AbstractVisual> visuals = new List<AbstractVisual>
            {
                new StaticTexture(AssetManager.NameToIndex[this.GetRandomStoneTexture()], RenderLayer.Stone)
            };

            return visuals;
        }

        private string GetRandomStoneTexture()
        {
            int r = StaticRandom.Rand(0, 2);
            string ret;

            if (r == 0)
            {
                ret = TextureLoader.TextureStone1;
            }
            else
            {
                ret = TextureLoader.TextureStone2;
            }

            return ret;
        }
    }
}