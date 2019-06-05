using System;
using System.Collections.Generic;
using System.Text;
using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Util;
using ProtoBuf;

namespace MagicalLifeMod.Core.Floor
{
    [ProtoContract]
    public class GrassFloor : MagicalLifeAPI.World.Base.Floor
    {
        public GrassFloor(bool walkable) : base(GetVisual(), walkable)
        {
        }

        protected GrassFloor()
        {
            //Protobuf-net constructor.
        }

        private static StaticTexture GetVisual()
        {
            int r = StaticRandom.Rand(0, 4);
            string textureName;

            switch (r)
            {
                case 0:
                    textureName = TextureLoader.TextureGrass1;
                    break;
                case 1:
                    textureName = TextureLoader.TextureGrass2;
                    break;
                case 2:
                    textureName = TextureLoader.TextureGrass3;
                    break;
                default:
                    textureName = TextureLoader.TextureGrass4;
                    break;
            }

            return new StaticTexture(AssetManager.GetTextureIndex(textureName), RenderLayer.GrassBase);
        }
    }
}
