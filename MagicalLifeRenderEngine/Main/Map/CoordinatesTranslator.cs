using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World;
using System.Drawing;

namespace MagicalLifeRenderEngine.Main.Map
{
    /// <summary>
    /// Used to translate screen coordinates to various values.
    /// </summary>
    public static class CoordinatesTranslator
    {
        /// <summary>
        /// Represents the top left most point of the section of the tile map bitmap.
        /// This will change later when the user can move the map around to see different sections.
        /// </summary>
        private static Point TopLeft = new Point(0, 0);

        /// <summary>
        /// Returns the location of the tile that resides at the specified point on screen.
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        public static Point3D GetTileLocation(Point mouse)
        {
            Microsoft.Xna.Framework.Point tileSize = Tile.GetTileSize();
            Point adjusted = new Point(mouse.X - TopLeft.X, mouse.Y - TopLeft.Y);

            return new Point3D(adjusted.X / tileSize.X, adjusted.Y / tileSize.Y, Pipe.RenderedHeight);
        }
    }
}