using System.Collections.Generic;
using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Visual.Rendering;
using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.World.Items
{
    [ProtoContract]
    public class StoneRubble : Item
    {
        public StoneRubble(int count) :
            base("Stone Rubble", 200,
            new System.Collections.Generic.List<string>()
            {
                "Stone Rubble",
                "Is dropped when stone is mined"
            },
            9999,
            count,
            typeof(StoneRubble), "StoneRubble_01")
        {
        }

        public StoneRubble()
        {
        }

        public override List<AbstractVisual> GetVisuals()
        {
            List<AbstractVisual> visuals = new List<AbstractVisual>();
            visuals.Add(new StaticTexture(AssetManager.NameToIndex["StoneRubble_01"], RenderLayer.Items));

            return visuals;
        }
    }
}