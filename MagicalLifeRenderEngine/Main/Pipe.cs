using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.World;

namespace MagicalLifeRenderEngine.Main
{
    /// <summary>
    /// <see cref="Pipe"/> is used to generate images on demand about various in game things.
    /// </summary>
    public class Pipe
    {
        /// <summary>
        /// Returns what each tile on the map at a specified height looks like.
        /// This is a 2D array.
        /// </summary>
        /// <param name="height">The level (z axis) that we should generate an image of all the tiles at. </param>
        /// <param name="world"></param>
        /// <returns></returns>
        public Bitmap GetTiles(int height, World world)
        {
            throw new NotImplementedException();
        }
    }
}
