using MLAPI.Asset;
using MLAPI.DataTypes;
using MLAPI.Visual.Rendering.Map;
using ProtoBuf;

namespace MLAPI.Visual.Rendering
{
    /// <summary>
    /// For when an object has only one texture, that always is the same.
    /// </summary>
    [ProtoContract]
    public class StaticTexture : AbstractVisual
    {
        [ProtoMember(1)]
        private int TextureId { get; set; }

        public StaticTexture(int textureId, int priority) : base(priority)
        {
            this.TextureId = textureId;
        }

        public StaticTexture()
        {
        }

        public override void Render(MapBatch batch, Point2D screenTopLeft)
        {
            batch.Draw(AssetManager.Textures[this.TextureId], screenTopLeft, this.Priority);
        }
    }
}