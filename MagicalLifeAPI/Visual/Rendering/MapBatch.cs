using MagicalLifeAPI.Components.Generic.Renderable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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

        /// <summary>
        /// Draws the <paramref name="texture"/> at the <paramref name="target"/> location. Applies a standard white mask.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="target"></param>
        public void Draw(Texture2D texture, Rectangle target)
        {
            int x = target.X + RenderInfo.XViewOffset;
            int y = target.Y + RenderInfo.YViewOffset;

            this.SpriteBat.Draw(texture, new Rectangle(x, y, target.Width, target.Height), Color.White);
        }

        internal void Draw(Texture2D texture, Vector2 target)
        {
            int x = (int)Math.Round(target.X + RenderInfo.XViewOffset);
            int y = (int)Math.Round(target.Y + RenderInfo.YViewOffset);

            this.SpriteBat.Draw(texture, new Vector2(x, y), Color.White);
        }
    }
}