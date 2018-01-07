using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeRenderEngine.Wave_Function_Collapse
{
    /// <summary>
    /// Simplifies the Wave Function Collapse project into something that I can use easily.
    /// </summary>
    public static class WaveFunctionAPI
    {
        private static Random random = new Random();

        /// <summary>
        /// Generates a different image from the original image.
        /// </summary>
        /// <param name="periodicInput"></param>
        /// <param name="ground"></param>
        /// <param name="limit">Something to do with balancing quality and time spent on the new image.</param>
        /// <param name="original">The original image to construct a new texture from.</param>
        /// <param name="n">How big each section that will be repeated in the new bitmap should be.</param>
        /// <param name="height">The height of the image to create. This could be larger than the original to create a smooth multi-tile image.</param>
        /// <param name="width">The width of the image to create. This could be larger than the original to create a smooth multi-tile image.</param>
        /// <returns></returns>
        public static Bitmap GetGeneratedImage(Bitmap original, int n, int width, int height, bool periodicInput, bool periodicOutput, int symmetry, int ground, int limit)
        {
            Model model = new OverlappingModel(original, n, width, height, periodicInput, periodicOutput, symmetry, ground);

            int seed = random.Next();
            bool finished = model.Run(seed, limit);

            return model.Graphics();
        }
    }
}
