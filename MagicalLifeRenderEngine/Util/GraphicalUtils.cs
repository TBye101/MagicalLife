using System.Drawing;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastBitmapLib;

namespace MagicalLifeRenderEngine.Util
{
    /// <summary>
    /// Does some graphically based utilities.
    /// </summary>
    public static class GraphicalUtils
    {
        /// <summary>
        /// Draws the source bitmap onto the target bitmap.
        /// The target bitmap must be of equal or greater size to the source bitmap.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="startingDestination">The point to begin drawing the source bitmap at onto the target bitmap.</param>
        /// <returns></returns>
        public static Bitmap DrawBitmapOnBitmap(Bitmap source, Bitmap target, Point startingDestination)
        {
            int width = source.Width;
            int height = source.Height;

            using (FastBitmap fastTarget = target.FastLock(), fastForeBitmap = source.FastLock())
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        fastTarget.SetPixel(x + startingDestination.X, y + startingDestination.Y, FlattenColor(fastTarget.GetPixelUInt(x, y), fastForeBitmap.GetPixelUInt(x, y)));
                    }
                }
            }
            
            return target;
        }

        /// <summary>
        /// Flattens two colors using a GDI+ like color blending mode
        /// </summary>
        /// <param name="backColor">The back color to blend</param>
        /// <param name="foreColor">The fore color to blend</param>
        /// <returns>The two colors, blended with a GDI+ like color bleding mode</returns>
        [Pure]
        public static uint FlattenColor(uint backColor, uint foreColor)
        {
            // Based off an answer by an anonymous user on StackOverlow http://stackoverflow.com/questions/1718825/blend-formula-for-gdi/2223241#2223241
            byte foreA = (byte)((foreColor >> 24) & 0xFF);

            if (foreA == 0)
            {
                return backColor;
            }

            if (foreA == 255)
            {
                return foreColor;
            }

            byte foreR = (byte)((foreColor >> 16) & 0xFF);
            byte foreG = (byte)((foreColor >> 8) & 0xFF);
            byte foreB = (byte)((foreColor) & 0xFF);

            byte backA = (byte)((backColor >> 24) & 0xFF);
            byte backR = (byte)((backColor >> 16) & 0xFF);
            byte backG = (byte)((backColor >> 8) & 0xFF);
            byte backB = (byte)((backColor) & 0xFF);

            float backAlphaFloat = backA;
            float foreAlphaFloat = foreA;

            float foreAlphaNormalized = foreAlphaFloat / 255;
            float backColorMultiplier = backAlphaFloat * (1 - foreAlphaNormalized);

            float alpha = backAlphaFloat + foreAlphaFloat - backAlphaFloat * foreAlphaNormalized;

            uint finalA = (uint)Math.Min(255, alpha);
            uint finalR = (uint)(Math.Min(255, (foreR * foreAlphaFloat + backR * backColorMultiplier) / alpha));
            uint finalG = (uint)(Math.Min(255, (foreG * foreAlphaFloat + backG * backColorMultiplier) / alpha));
            uint finalB = (uint)(Math.Min(255, (foreB * foreAlphaFloat + backB * backColorMultiplier) / alpha));

            return finalA << 24 | finalR << 16 | finalG << 8 | finalB;
        }
    }
}