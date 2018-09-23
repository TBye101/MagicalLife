using MagicalLifeAPI.Asset;
using MagicalLifeAPI.DataTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public override void Render(SpriteBatch batch, Rectangle bounds)
        {
            batch.Draw(AssetManager.Textures[this.TextureID], bounds, Color.White);
        }
    }
}