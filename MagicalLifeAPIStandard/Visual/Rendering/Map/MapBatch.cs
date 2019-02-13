using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Util.Reusable;
using MagicalLifeAPI.Visual.Rendering.Renderer;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static MagicalLifeGUIWindows.Rendering.Text.SimpleTextRenderer;

namespace MagicalLifeGUIWindows.Rendering.Map
{
    /// <summary>
    /// Used to render objects in the map while accounting for things like offsets.
    /// </summary>
    public class MapBatch
    {
        private SpriteBatch SpriteBat;

        /// <summary>
        /// Updates the internal handle to a new <see cref="SpriteBatch"/>.
        /// This should be called every frame.
        /// </summary>
        /// <param name="spBatch"></param>
        public void UpdateSpriteBatch(SpriteBatch spBatch)
        {
            this.SpriteBat = spBatch;
        }

        public void DrawText(string text, Rectangle target, SpriteFont font, Alignment alignment, int renderLayer)
        {
            int x = target.X + RenderInfo.XViewOffset;
            int y = target.Y + RenderInfo.YViewOffset;

            Rectangle newTarget = new Rectangle(x, y, target.Width, target.Height);
            SimpleTextRenderer.DrawString(font, text, newTarget, alignment, Color.White, ref this.SpriteBat, renderLayer);
        }

        /// <summary>
        /// Draws the <paramref name="texture"/> at the <paramref name="target"/> location. Applies a standard white mask.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="target"></param>
        public void Draw(Texture2D texture, Rectangle target, int renderLayer)
        {
            Vector2 position = new Vector2(target.X, target.Y);
            this.SpriteBat.Draw(texture, target, null, Color.White, 0.0F, new Vector2(0, 0), SpriteEffects.None, renderLayer);
        }

        /// <summary>
        /// Draws a section of the texture at the target location.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="target">The target location to draw at.</param>
        /// <param name="textureSection">The section of the texture that will be drawn.</param>
        public void Draw(Texture2D texture, Vector2 target, Rectangle textureSection, int renderLayer)
        {
            Rectangle targetRect = new Rectangle((int)target.X, (int)target.Y, texture.Bounds.Width, texture.Bounds.Height);
            this.SpriteBat.Draw(texture, targetRect, textureSection, Color.White, 0F, new Vector2(0, 0), SpriteEffects.None, renderLayer);
        }

        public void Draw(Texture2D texture, Vector2 target, int renderLayer)
        {
            Rectangle targetRect = new Rectangle((int)target.X, (int)target.Y, texture.Bounds.Width, texture.Bounds.Height);
            this.Draw(texture, targetRect, renderLayer);
        }
    }
}