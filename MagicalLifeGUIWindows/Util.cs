using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows
{
    /// <summary>
    /// Various utilities.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Returns the in game tile coordinates of the specified point on the screen.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Point GetMapLocation(int x, int y, int dimension, out bool success)
        {
            int x2 = x + Rendering.RenderingPipe.XViewOffset;
            int y2 = y + Rendering.RenderingPipe.YViewOffset;
            Point size = Tile.GetTileSize();

            x2 /= size.X;
            y2 /= size.Y;

            if (World.Dimensions[dimension].DoesTileExist(x2, y2))
            {
                success = true;
                return new Point(x2, y2);
            }
            else
            {
                success = false;
                throw new System.Exception("Map location doesn't exist!");
            }
        }
    }
}