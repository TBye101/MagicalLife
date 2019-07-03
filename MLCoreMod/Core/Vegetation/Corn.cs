using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Items;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// A maple tree.
    /// </summary>
    [ProtoContract]
    public class Corn : Vegetation
    {
        private static readonly string Name = "Corn Plant";

        private static readonly int MinimumCornYield = 1;
        private static readonly int MaximumCornYield = 7;
        private static readonly int DefaultCornDurability = 5;

        public static StaticTexture CornSeedling { get; set; }
        public static StaticTexture CornGrowth1 { get; set; }
        public static StaticTexture CornGrowth2 { get; set; }
        public static StaticTexture CornFullGrowth { get; set; }

        public Corn(string name, int durability, ComponentHarvestable harvestBehavior)
            : base(Name, durability, harvestBehavior, true)
        {
            // Determine corn yield
            Random random = new Random();
            int cornYield = random.Next(MinimumCornYield, MaximumCornYield);

            this.Durability = DefaultCornDurability;

            // initialize harvesting list
            List<Base.Item> list = new List<Base.Item>
            {
                new CornEar(cornYield)
            };

            this.AddComponent(new DropWhenCompletelyHarvested(list, SoundsTable.TreeFall, SoundsTable.TreeFall));

            ComponentHasTexture textureComponent = this.GetExactComponent<ComponentHasTexture>();
            textureComponent.Visuals.Add(CornSeedling);
            textureComponent.Visuals.Add(CornGrowth1);
            textureComponent.Visuals.Add(CornGrowth2);
            textureComponent.Visuals.Add(CornFullGrowth);
        }

        public Corn()
        {
        }
    }
}