using MagicalLifeGUIWindows.Rendering;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Splash
{
    /// <summary>
    /// A splash screen that displays an logo, then goes away.
    /// </summary>
    public class SplashScreen
    {
        protected const int FPS = 60;

        protected Rectangle DisplayZone { get; set; }

        protected Rectangle TextZone { get; set; }

        protected string Text { get; set; }

        protected SpriteFont Font = Game1.AssetManager.Load<SpriteFont>("MainMenuFont12x");

        /// <summary>
        /// How many frames to show the splash screen.
        /// </summary>
        protected int Frames { get; set; }

        protected Texture2D Logo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logoFileName">The resource path to the logo file that is to be displayed.</param>
        /// <param name="duration">How many seconds to show the logo.</param>
        public SplashScreen(string logo, float duration, string text = "")
        {
            this.Frames = (int)duration * SplashScreen.FPS; 
            this.Logo = Game1.AssetManager.Load<Texture2D>(logo);
            this.DisplayZone = this.CalculateDisplayLocation();
            this.Text = text;
            this.CalculateTextZone();
        }

        /// <summary>
        /// If true, this splash screen is done showing.
        /// </summary>
        /// <returns></returns>
        public bool Done()
        {
            return this.Frames <= 0;
        }

        public void Draw(ref SpriteBatch spBatch)
        {
            spBatch.Draw(this.Logo, this.DisplayZone, RenderingPipe.colorMask);
            SimpleTextRenderer.DrawString(this.Font, this.Text, this.TextZone, SimpleTextRenderer.Alignment.Left, RenderingPipe.colorMask, ref spBatch);
            this.Frames--;
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

            if (this.Logo.Bounds.Width < RenderingPipe.FullScreenWindow.Width)
            {
                width = this.Logo.Bounds.Width;
            }
            else
            {
                width = RenderingPipe.FullScreenWindow.Width;
            }

            if (this.Logo.Bounds.Height < RenderingPipe.FullScreenWindow.Height)
            {
                height = this.Logo.Bounds.Height;
            }
            else
            {
                height = RenderingPipe.FullScreenWindow.Height;
            }

            if (this.Logo.Bounds.Width < RenderingPipe.FullScreenWindow.Width)
            {
                x = (RenderingPipe.FullScreenWindow.Size.X - this.Logo.Bounds.Size.X) / 2;
            }
            else
            {
                x = RenderingPipe.FullScreenWindow.Width;
            }

            if (this.Logo.Bounds.Height < RenderingPipe.FullScreenWindow.Height)
            {
                y = (RenderingPipe.FullScreenWindow.Size.Y - this.Logo.Bounds.Size.Y) / 2;
            }
            else
            {
                y = RenderingPipe.FullScreenWindow.Height;
            }

            return new Rectangle(x, y, width, height);
        }
    }
}
