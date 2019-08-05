using System;
using MLAPI.DataTypes;
using MLAPI.World.Base;
using MLAPI.World.Data;

namespace MonoGUI.MonoGUI
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
        public static Point3D GetMapLocation(int x, int y, Guid dimensionId, out bool success)
        {
            Point2D size = Tile.GetTileSize();

            int tileX = x / size.X;
            int tileY = y / size.Y;

            if (World.Dimensions.Count > 0 && World.Dimensions[dimensionId].DoesTileExist(tileX, tileY))
            {
                success = true;
                return new Point3D(tileX, tileY, dimensionId);
            }
            else
            {
                success = false;
                return null;
            }
        }
    }
}