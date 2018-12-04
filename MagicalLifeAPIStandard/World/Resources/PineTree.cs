using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.Visual.Rendering.AbstractVisuals;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Items;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// A pine tree.
    /// </summary>
    [ProtoContract]
    public class PineTree : TreeBase
    {
        private static readonly string Name = "Maple Tree";
        public static readonly int Durabilitie = 20;

        private static readonly StaticTexture Stump = new
            StaticTexture(AssetManager.NameToIndex[TextureLoader.PineStump], RenderLayer.TreeStump);

        private static readonly StaticTexture Trunk = new
            StaticTexture(AssetManager.NameToIndex[TextureLoader.PineTrunk], RenderLayer.TreeTrunk);

        private static readonly StaticTexture Leaves = new
            StaticTexture(AssetManager.NameToIndex[TextureLoader.PineLeaves1], RenderLayer.TreeLeaves);


        private static readonly int XOffset = Tile.GetTileSize().X / -2;
        private static readonly int YOffset = Tile.GetTileSize().Y * -3 / 2;

        private static readonly OffsetTexture OffsetStump = new OffsetTexture(RenderLayer.TreeStump, Stump, XOffset, YOffset);
        private static readonly OffsetTexture OffsetTrunk = new OffsetTexture(RenderLayer.TreeTrunk, Trunk, XOffset, YOffset);
        private static readonly OffsetTexture OffsetLeaves = new OffsetTexture(RenderLayer.TreeLeaves, Leaves, XOffset, YOffset);

        public PineTree(int durability) : base(Name, durability)
        {
            this.HarvestingBehavior = new DropWhenCompletelyHarvested(new List<Base.Item>()
            {
                new Log(1, this.Durability)
            }, SoundsTable.UIClick);
        }

        public PineTree() : base()
        {

        }

        public override AbstractHarvestable HarvestingBehavior { get; set; }

        public override List<AbstractVisual> GetVisuals()
        {
            List<AbstractVisual> ret = new List<AbstractVisual>
            {

                OffsetTrunk,
                OffsetLeaves,
                OffsetStump
            };

            return ret;
        }
    }
}
