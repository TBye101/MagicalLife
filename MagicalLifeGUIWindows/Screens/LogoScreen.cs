using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MagicalLifeGUIWindows.Screens
{
    /// <summary>
    /// A splash screen that displays an logo, then goes away.
    /// </summary>
    public class LogoScreen
    {
        protected const int FPS = 60;

        protected Rectangle DisplayZone { get; set; }

        protected Rectangle TextZone { get; set; }

        protected string Text { get; set; }

        protected SpriteFont Font = Game1.AssetManager.Load<SpriteFont>(TextureLoader.FontMainMenuFont12x);

        /// <summary>
        /// How many frames to show the splash screen.
        /// </summary>
        protected int Frames { get; set; }

        /// <summary>
        /// Half of frames, so that the fade out can occur.
        /// </summary>
        protected int Half { get; set; }

        protected Texture2D Logo { get; set; }

        protected Color Mask { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="logoFileName">The resource path to the logo file that is to be displayed.</param>
        /// <param name="duration">How many seconds to show the logo.</param>
        public LogoScreen(string logo, float duration, string text = "")
        {
            this.Frames = (int)duration * LogoScreen.FPS;
            this.Half = this.Frames / 2;
            this.Logo = Game1.AssetManager.Load<Texture2D>(logo);
            this.DisplayZone = this.CalculateDisplayLocation();
            this.Text = text;
            this.CalculateTextZone();
            this.Mask = Color.Black;
        }

        public void Skip()
        {
            this.Frames = 0;
        }

        /// <summary>
        /// If true, this splash screen is done showing.
        /// </summary>
        /// <returns></returns>
        public bool Done()
        {
            return this.Frames <= 0;
        }

        public void Draw(SpriteBatch spBatch)
        {
            spBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            spBatch.Draw(this.Logo, this.DisplayZone.Center.ToVector2(), null, this.CalculateMask(), 0, new Vector2(this.Logo.Width / 2, this.Logo.Height / 2), 1.0f, SpriteEffects.None, 1.0f);
            SimpleTextRenderer.DrawString(this.Font, this.Text, this.TextZone, SimpleTextRenderer.Alignment.Left, Color.White, spBatch, RenderLayer.GUI);

            this.Frames--;
            spBatch.End();
        }

        /// <summary>
        /// Calculates the color mask to apply, in order to apply fade in fade out effects.
        /// </summary>
        /// <returns></returns>
        private Color CalculateMask()
        {
            int modifier = 255 / this.Half;

            if (this.Half < this.Frames)
            {
                //Fade in
                this.Mask = new Color(this.Mask.R + modifier, this.Mask.G + modifier, this.Mask.B + modifier);
            }
            else
            {
                //Fade out
                this.Mask = new Color(this.Mask.R - modifier, this.Mask.G - modifier, this.Mask.B - modifier);
            }

            return this.Mask;
        }

        private void CalculateTextZone()
        {
            int x = 0;
            int y = 0;
            int width;
            int height;

            Vector2 result = this.Font.MeasureString(this.Text);
            width = (int)Math.Round(result.X);
            height = (int)Math.Round(result.Y);

            this.TextZone = new Rectangle(x, y, width, height);
        }

        private Rectangle CalculateDisplayLocation()
        {
            int x;
            int y;

            int width;
            int height;

            if (this.Logo.Bounds.Width < RenderInfo.FullScreenWindow.Width)
            {
                width = this.Logo.Bounds.Width;
            }
            else
            {
                width = RenderInfo.FullScreenWindow.Width;
            }

            if (this.Logo.Bounds.Height < RenderInfo.FullScreenWindow.Height)
            {
                height = this.Logo.Bounds.Height;
            }
            else
            {
                height = RenderInfo.FullScreenWindow.Height;
            }

            if (this.Logo.Bounds.Width < RenderInfo.FullScreenWindow.Width)
            {
                x = (RenderInfo.FullScreenWindow.Size.X - this.Logo.Bounds.Size.X) / 2;
            }
            else
            {
                x = 0;
            }

            if (this.Logo.Bounds.Height < RenderInfo.FullScreenWindow.Height)
            {
                y = (RenderInfo.FullScreenWindow.Size.Y - this.Logo.Bounds.Size.Y) / 2;
            }
            else
            {
                y = 0;
            }

            return new Rectangle(x, y, width, height);
        }
    }
}