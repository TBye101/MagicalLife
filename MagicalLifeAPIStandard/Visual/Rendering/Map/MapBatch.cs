using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Util.Reusable;
using MagicalLifeAPI.Visual.Rendering.Renderer;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        /// Holds all of the rendering actions that need to happen.
        /// </summary>
        private readonly List<RenderCallHolder> RenderActions = new List<RenderCallHolder>();

        private readonly RenderCallHolderComparer Comparator = new RenderCallHolderComparer();

        private readonly Counter CallCounter = new Counter();

        /// <summary>
        /// Updates the internal handle to a new <see cref="SpriteBatch"/>.
        /// This should be called every frame.
        /// </summary>
        /// <param name="spBatch"></param>
        internal void UpdateSpriteBatch(SpriteBatch spBatch)
        {
            this.SpriteBat = spBatch;
        }

        /// <summary>
        /// Renders the backlog of rendering jobs to completion.
        /// </summary>
        internal void RenderAll()
        {
            if (this.RenderActions.Count > 0)
            {
                this.RenderActions.Sort(this.Comparator);

                foreach (RenderCallHolder item in this.RenderActions)
                {
                    item.Action.Invoke();
                }

                this.RenderActions.Clear();
                this.CallCounter.Reset();
            }
        }

        /// <summary>
        /// Draws the <paramref name="texture"/> at the <paramref name="target"/> location. Applies a standard white mask.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="target"></param>
        /// <param name="renderLayer">The layer in which this rendering call should be made.</param>
        public void Draw(Texture2D texture, Rectangle target, int renderLayer)
        {
            void renderCall() => this.Draw(texture, target);
            this.RenderActions.Add(new RenderCallHolder(renderLayer, renderCall, this.CallCounter.Increment()));
        }

        /// <summary>
        /// Draws text at the specified location within the map, accounting for player view positioning.
        /// </summary>
        public void DrawText(string text, Rectangle target, SpriteFont font, Alignment alignment, int renderLayer)
        {
            void renderCall() => this.DrawText(text, target, font, alignment);
            this.RenderActions.Add(new RenderCallHolder(renderLayer, renderCall, this.CallCounter.Increment()));
        }

        private void DrawText(string text, Rectangle target, SpriteFont font, Alignment alignment)
        {
            SimpleTextRenderer.DrawString(font, text, target, alignment, Color.White, this.SpriteBat, 0);
        }

        /// <summary>
        /// Draws the <paramref name="texture"/> at the <paramref name="target"/> location. Applies a standard white mask.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="target"></param>
        private void Draw(Texture2D texture, Rectangle target)
        {
            this.SpriteBat.Draw(texture, target, Color.White);
        }

        /// <summary>
        /// Draws a section of the texture at the target location.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="target">The target location to draw at.</param>
        /// <param name="textureSection">The section of the texture that will be drawn.</param>
        public void Draw(Texture2D texture, Vector2 target, Rectangle textureSection, int renderLayer)
        {
            void renderCall() => this.Draw(texture, target, textureSection);
            this.RenderActions.Add(new RenderCallHolder(renderLayer, renderCall, this.CallCounter.Increment()));
        }

        /// <summary>
        /// Draws a section of the texture at the target location.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="target">The target location to draw at.</param>
        /// <param name="textureSection">The section of the texture that will be drawn.</param>
        private void Draw(Texture2D texture, Vector2 target, Rectangle textureSection)
        {
            this.SpriteBat.Draw(texture, target, textureSection, Color.White);
        }

        public void Draw(Texture2D texture, Vector2 target, int renderLayer)
        {
            void renderCall() => this.Draw(texture, target);
            this.RenderActions.Add(new RenderCallHolder(renderLayer, renderCall, this.CallCounter.Increment()));
        }

        private void Draw(Texture2D texture, Vector2 target)
        {
            this.SpriteBat.Draw(texture, target, Color.White);
        }
    }
}