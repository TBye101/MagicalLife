using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Items;
using ProtoBuf;

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

        private static readonly StaticTexture Stump = new
            StaticTexture(AssetManager.NameToIndex[TextureLoader.OakStump], RenderLayer.TreeStump);

        private static readonly StaticTexture Trunk = new
            StaticTexture(AssetManager.NameToIndex[TextureLoader.OakTrunk], RenderLayer.TreeTrunk);

        private static readonly StaticTexture Leaves = new
            StaticTexture(AssetManager.NameToIndex[TextureLoader.OakLeaves1], RenderLayer.TreeLeaves);

        public OakTree(int durability) : base(Name, durability)
        {
            this.HarvestingBehavior = new DropWhenCompletelyHarvested(new List<Base.Item>()
            {
                new StoneRubble(this.Durability)
            }, SoundsTable.UIClick);
        }

        public OakTree() : base()
        {

        }

        public override AbstractHarvestable HarvestingBehavior { get; set; }

        public override List<AbstractVisual> GetVisuals()
        {
            List<AbstractVisual> ret = new List<AbstractVisual>
            {
                Trunk,
                Leaves,
                Stump
            };

            return ret;
        }
    }
}