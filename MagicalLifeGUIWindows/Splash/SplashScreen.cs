using MagicalLifeGUIWindows.Rendering;
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
        public SplashScreen(string logo, float duration)
        {
            this.Frames = (int)duration * SplashScreen.FPS; 
            this.Logo = Game1.AssetManager.Load<Texture2D>(logo);
            this.DisplayZone = this.CalculateDisplayLocation();
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
            this.Frames--;
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
