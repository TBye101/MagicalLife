using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.GUI
{
    /// <summary>
    /// Any class that inherits from this has a texture.
    /// </summary>
    [ProtoBuf.ProtoContract]
    [ProtoBuf.ProtoInclude(1, typeof(Tile))]
    [ProtoBuf.ProtoInclude(3, typeof(Item))]
    [ProtoInclude(4, typeof(Resource))]
    public class HasTexture
    {
        [ProtoMember(5)]
        public Guid ID { get; }

        /// <summary>
        /// The index of the texture in our asset manager.
        /// </summary>
        [ProtoBuf.ProtoMember(2)]
        public int TextureIndex { get; set; }

        public HasTexture(int textureIndex)
        {
            this.TextureIndex = textureIndex;
            this.ID = Guid.NewGuid();
        }

        public HasTexture()
        {
        }
    }
}