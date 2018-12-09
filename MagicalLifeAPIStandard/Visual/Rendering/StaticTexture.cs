using MagicalLifeAPI.Asset;
using MagicalLifeAPI.DataTypes;
using MagicalLifeGUIWindows.Rendering.Map;
using ProtoBuf;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// For when an object has only one texture, that always is the same.
    /// </summary>
    [ProtoContract]
    public class StaticTexture : AbstractVisual
    {
        [ProtoMember(1)]
        private int TextureID { get; set; }

        public StaticTexture(int textureID, int priority) : base(priority)
        {
            this.TextureID = textureID;
        }

        public StaticTexture()
        {
        }

        public override void Render(MapBatch batch, Point2D ScreenTopLeft)
        {
            batch.Draw(AssetManager.Textures[this.TextureID], ScreenTopLeft, this.Priority);
        }
    }
}