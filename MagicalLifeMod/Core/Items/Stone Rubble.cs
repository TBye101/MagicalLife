using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World.Base;
using MagicalLifeMod.Core;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Items
{
    [ProtoContract]
    public class StoneRubble : Item
    {
        public StoneRubble(int count) :
            base("Stone Rubble",
            new System.Collections.Generic.List<string>()
            {
                "Stone Rubble",
                "Is dropped when stone is mined"
            },
            9999,
            count,
            TextureLoader.TextureStoneRubble1, 15, DescriptionValues.DisplayName)
        {
        }

        public StoneRubble()
        {
        }

        private string GetRandomStoneRubbleTexture()
        {
            int r = StaticRandom.Rand(0, 2);
            string ret;

            if (r == 0)
            {
                ret = TextureLoader.TextureStoneRubble1;
            }
            else
            {
                ret = TextureLoader.TextureStoneRubble2;
            }

            return ret;
        }

        public override Item GetDeepCopy(int amount)
        {
            return new StoneRubble(amount);
        }

        public override List<AbstractVisual> GetVisuals()
        {
            List<AbstractVisual> visuals = new List<AbstractVisual>();
            visuals.Add(new StaticTexture(AssetManager.NameToIndex[this.GetRandomStoneRubbleTexture()], RenderLayer.Items));

            return visuals;
        }
    }
}