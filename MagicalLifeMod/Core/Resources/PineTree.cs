using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Properties;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.Visual.Rendering.AbstractVisuals;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Items;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// A pine tree.
    /// </summary>
    [ProtoContract]
    public class PineTree : TreeBase
    {
        private static readonly string Name = Lang.PineTree;
        public static readonly int Durabilitie = 20;

        public static readonly int XOffset = Tile.GetTileSize().X / -2;
        public static readonly int YOffset = Tile.GetTileSize().Y * -3 / 2;

        public static OffsetTexture OffsetStump { get; set; }
        public static OffsetTexture OffsetTrunk { get; set; }
        public static OffsetTexture OffsetLeaves { get; set; }

        public PineTree(int durability) : base(Name, durability, GetHarvestBehavior())
        {
        }

        public PineTree()
        {
        }

        private void InitializeComponents()
        {
            ComponentHasTexture textureComponent = this.GetExactComponent<ComponentHasTexture>();

            textureComponent.Visuals.Add(OffsetTrunk);
            textureComponent.Visuals.Add(OffsetLeaves);
            textureComponent.Visuals.Add(OffsetStump);
        }

        private static ComponentHarvestable GetHarvestBehavior()
        {
            return new DropWhenCompletelyHarvested(new List<Item>
            {
                new Log(1)
            }, SoundsTable.AxeHit, SoundsTable.TreeFall);
        }
    }
}