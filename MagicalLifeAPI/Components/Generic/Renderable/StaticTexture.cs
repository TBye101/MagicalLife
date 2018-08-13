using MagicalLifeAPI.DataTypes;
using ProtoBuf;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// For when an object has only one texture, that always is the same.
    /// </summary>
    [ProtoContract]
    public class StaticTexture : AbstractRenderable
    {
        public StaticTexture(int textureID)
        {
            this.TextureID = textureID;
        }

        public StaticTexture()
        {
        }

        [ProtoMember(1)]
        public override int TextureID { get; set; }

        public override void CalculateTexture(ProtoArray<World.Base.Tile> tiles, Point2D myLocation)
        {
            //Static textures don't change
        }
    }
}