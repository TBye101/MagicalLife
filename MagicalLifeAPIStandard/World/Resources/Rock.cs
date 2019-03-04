using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
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

        public override AbstractHarvestable HarvestingBehavior { get; set; }

        public Rock(int durability) : base(StoneName, durability)
        {
            this.HarvestingBehavior = new DropWhenCompletelyHarvested(new List<Base.Item>
            {
                new StoneRubble(this.Durability)
            }, SoundsTable.PickaxeHit, SoundsTable.MiningFinish);
        }

        public Rock()
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