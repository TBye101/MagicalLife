using MagicalLifeRenderEngine.Util;
using MagicalLifeAPI.World;
using FastBitmapLib;
using MagicalLifeSettings.Storage;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeRenderEngine.Main.GUI
{
    /// <summary>
    /// Knows how to draw the end turn button properly onto the screen.
    /// </summary>
    public static class EndTurnButtonGUI
    {
        private static Bitmap State1;
        private static Bitmap State2;

        private static readonly int scaleSize = 20;
        private static Size ImageSize;
        private static Size screenSize;

        static EndTurnButtonGUI()
        {
            screenSize = MainWindow.Default.ScreenSize;
            ImageSize = new Size(screenSize.Width / scaleSize, screenSize.Height / scaleSize);

            Bitmap s1 = TextureRegister.GetTexture("EndTurnButtonState1.png");
            Bitmap s2 = TextureRegister.GetTexture("EndTurnButtonState2.png");

            EndTurnButtonGUI.State1 = new Bitmap(s1, ImageSize);
            EndTurnButtonGUI.State2 = new Bitmap(s2, ImageSize);
        }

        /// <summary>
        /// Draws the end turn button onto the screen properly.
        /// </summary>
        /// <param name="screen"></param>
        public static void Draw(ref Bitmap screen)
        {
            //FastBitmap fast = screen.FastLock();

            Bitmap currentTexture;

            if (World.IsPlayersTurn)
            {
                currentTexture = State2;
            }
            else
            {
                currentTexture = State1;
            }

            //Rectangle destination = new Rectangle(new Point(screenSize.Width - ImageSize.Width, screenSize.Height - ImageSize.Height), ImageSize);
            //fast.CopyRegion(currentTexture, new Rectangle(new Point(0, 0), ImageSize), destination);
            GraphicalUtils.DrawBitmapOnBitmap(currentTexture, screen, new Point(screenSize.Width - ImageSize.Width, screenSize.Height - (int)(ImageSize.Height * 1.75)));

            //fast.Unlock();
        }
    }
}
