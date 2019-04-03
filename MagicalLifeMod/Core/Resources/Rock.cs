using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Sound;
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
    public class Rock : RockBase
    {
        public static readonly string StoneName = "Stone";

        public Rock(int count) : base(StoneName, count, GetHarvestBehavior(count))
        {
            this.GetExactComponent<ComponentHasTexture>().Visuals.Add(this.GetTextureInstance());
            
        }

        private static ComponentHarvestable GetHarvestBehavior(int count)
        {
            return new DropWhenCompletelyHarvested(new List<Base.Item>
            {
                new StoneRubble(count)
            }, SoundsTable.PickaxeHit, SoundsTable.MiningFinish);
        }

        public Rock()
        {
        }

        /// <summary>
        /// Returns a new instance of the stone texture.
        /// </summary>
        /// <returns></returns>
        private AbstractVisual GetTextureInstance()
        {
            return new StaticTexture(AssetManager.NameToIndex[this.GetRandomStoneTexture()], RenderLayer.Stone);
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