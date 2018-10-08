using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
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
        public override AbstractMinable MiningBehavior { get; set; }

        public Stone(int durability) : base("Stone", durability)
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
            return "Stone";
        }

        public override List<AbstractVisual> GetVisuals()
        {
            List<AbstractVisual> visuals = new List<AbstractVisual>
            {
                new StaticTexture(AssetManager.NameToIndex["Stone"], RenderLayer.Stone)
            };

            return visuals;
        }
    }
}