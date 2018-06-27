using MagicalLifeAPI.Universal;

namespace MagicalLifeAPI.GUI
{
    /// <summary>
    /// Any class that inherits from this has a texture.
    /// </summary>
    [ProtoBuf.ProtoContract]
    //[ProtoBuf.ProtoInclude(1, typeof(Tile))]
    public class HasTexture : Unique
    {
        /// <summary>
        /// The index of the texture in our asset manager.
        /// </summary>
        [ProtoBuf.ProtoMember(2)]
        public int TextureIndex { get; set; }

        public HasTexture(int textureIndex)
        {
            this.TextureIndex = textureIndex;
        }

        public HasTexture()
        {
        }
    }
}