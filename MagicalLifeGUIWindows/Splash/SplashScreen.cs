using MagicalLifeGUIWindows.Rendering;
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
            spBatch.Draw(this.Logo, RenderingPipe.FullScreenWindow, RenderingPipe.colorMask);
            this.Frames--;
        }
    }
}
