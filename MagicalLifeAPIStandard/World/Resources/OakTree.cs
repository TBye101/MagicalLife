using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.Visual.Rendering.AbstractVisuals;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Items;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Resources.Tree
{
    /// <summary>
    /// An oak tree.
    /// </summary>
    [ProtoContract]
    public class OakTree : TreeBase
    {
        private static readonly string Name = "Oak Tree";
        public static readonly int Durabilitie = 20;

        public static readonly int XOffset = Tile.GetTileSize().X / -2;
        public static readonly int YOffset = Tile.GetTileSize().Y * -3 / 2;

        public static OffsetTexture OffsetStump { get; set; }
        public static OffsetTexture OffsetTrunk { get; set; }
        public static OffsetTexture OffsetLeaves { get; set; }

        public OakTree(int durability) : base(Name, durability)
        {
            this.HarvestingBehavior = new DropWhenCompletelyHarvested(new List<Base.Item>
            {
                new Log(1, this.Durability)
            }, SoundsTable.AxeHit, SoundsTable.TreeFall);
        }

        public OakTree()
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