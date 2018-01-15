using MagicalLifeAPI.World.Tiles;
using MagicalLifeAPI.World;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeRenderEngine.Main
{
    /// <summary>
    /// Used to generate the image of a tile.
    /// </summary>
    public static class TileImageGenerator
    {
        /// <summary>
        /// Generates the image of a tile.
        /// </summary>
        /// <returns></returns>
        public static Bitmap GenerateTileImage(Tile tile)
        {
            Bitmap tileImage = TextureRegister.GetTexture(tile.GetTextureName());

            Graphics g = Graphics.FromImage(tileImage);

            if (tile.Living.Count > 0)
            {
                g.DrawImage(TextureRegister.GetTexture(tile.Living.ElementAt(0).GetTextureName()), new Point(0, 0));
            }

            return tileImage;
        }
    }
}
