using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Tiles
{
    [ProtoBuf.ProtoContract]
    class TilledDirt : Tile
    {
        public override ComponentRenderer CompositeRenderer { get; set; }

        public TilledDirt(Point2D location) : base(location, 10, 0)
        {
            this.CompositeRenderer = new ComponentRenderer();
            this.CompositeRenderer.RenderQueue.Visuals.Add(new StaticTexture(TilledDirt.GetTextureID(), RenderLayer.DirtBase));
        }

        public static int GetTextureID()
        {
            return AssetManager.GetTextureIndex(TextureLoader.TextureTilledDirt);
        }

        public override string GetName()
        {
            return "TilledDirt";
        }
    }
}
