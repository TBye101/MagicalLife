using System.Collections.Generic;
using MLAPI.Asset;
using MLAPI.Components.Resource;
using MLAPI.Properties;
using MLAPI.Sound;
using MLAPI.Util.RandomUtils;
using MLAPI.Visual;
using MLAPI.Visual.Rendering;
using MLAPI.World.Base;
using MLAPI.World.Resources;
using MLCoreMod.Core.Items;
using ProtoBuf;

namespace MLCoreMod.Core.Resources
{
    /// <summary>
    /// Stone as a resource.
    /// </summary>
    [ProtoContract]
    public class Rock : RockBase
    {
        private AbstractVisual visual;

        public Rock(int count) : base(Lang.StoneName, count, GetHarvestBehavior(count))
        {
            this.GetExactComponent<ComponentHasTexture>().Visuals.Add(this.GetTextureInstance());
        }

        private static ComponentHarvestable GetHarvestBehavior(int count)
        {
            return new DropWhenCompletelyHarvested(new List<Item>
            {
                new StoneRubble(count)
            }, SoundsTable.PickaxeHit, SoundsTable.MiningFinish);
        }

        public Rock()
        {
            visual = new StaticTexture(AssetManager.NameToIndex[this.GetRandomStoneTexture()], RenderLayer.MainObject);
        }

        /// <summary>
        /// Returns a new instance of the stone texture.
        /// </summary>
        /// <returns></returns>
        private AbstractVisual GetTextureInstance()
        {
            return new StaticTexture(AssetManager.NameToIndex[this.GetRandomStoneTexture()], RenderLayer.MainObject);
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