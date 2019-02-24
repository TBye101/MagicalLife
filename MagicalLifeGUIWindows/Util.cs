using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;

namespace MagicalLifeGUIWindows
{
    /// <summary>
    /// Various utilities.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Returns the in game tile coordinates of the specified Point2D on the screen.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Point2D GetMapLocation(int x, int y, int dimension, out bool success)
        {
            Point2D size = Tile.GetTileSize();

            int tileX = x / size.X;
            int tileY = y / size.Y;

            if (World.Dimensions.Count > 0 && World.Dimensions[dimension].DoesTileExist(tileX, tileY))
            {
                success = true;
                return new Point2D(tileX, tileY);
            }
            else
            {
                success = false;
                return null;
            }
        }
    }
}