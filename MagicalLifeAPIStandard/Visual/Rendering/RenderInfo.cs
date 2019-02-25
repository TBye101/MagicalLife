using MagicalLifeAPI.DataTypes;
using Microsoft.Xna.Framework;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    public static class RenderInfo
    {
        /// <summary>
        /// The standard size of the tiles.
        /// </summary>
        public static readonly Point tileSize = MagicalLifeAPI.World.Base.Tile.GetTileSize();

        public static Rectangle FullScreenWindow { get; set; }

        /// <summary>
        /// The standard color mask to apply to all tiles.
        /// </summary>
        public static readonly Color colorMask = Color.White;

        /// <summary>
        /// The zoom level of the map.
        /// </summary>
        public static float Zoom { get; set; } = 1F;

        /// <summary>
        /// The currently viewed dimension.
        /// </summary>
        public static int Dimension { get; set; }

        /// <summary>
        /// The game's current FPS.
        /// </summary>
        public static int GameFPS { get; private set; } = 60;

        public static Camera Camera2D { get; set; } = new Camera();

        /// <summary>
        /// Returns the center of the player's screen view.
        /// </summary>
        /// <returns></returns>
        public static Point2D GetCameraCenter()
        {
            int x = (FullScreenWindow.Width / 2) + (int)Camera2D.Position.X;
            int y = (FullScreenWindow.Height / 2) + (int)Camera2D.Position.Y;

            return new Point2D(x, y);
        }
    }
}