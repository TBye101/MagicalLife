using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using Microsoft.Xna.Framework;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    public static class RenderInfo
    {
        /// <summary>
        /// The standard size of the tiles.
        /// </summary>
        public static readonly Point tileSize = MagicalLifeAPI.World.Base.Tile.GetTileSize();

        public static readonly Rectangle FullScreenWindow =
            new Rectangle(new Point(0, 0),
            new Point(MagicalLifeSettings.Storage.MainWindow.Default.ScreenSize.Width, MagicalLifeSettings.Storage.MainWindow.Default.ScreenSize.Height));

        /// <summary>
        /// The standard color mask to apply to all tiles.
        /// </summary>
        public static readonly Color colorMask = Color.White;

        /// <summary>
        /// The x offset of the view due to the player moving the camera around the map.
        /// </summary>
        public static int XViewOffset { get; set; }

        /// <summary>
        /// The y offset of the view due to the player moving the camera around the map.
        /// </summary>
        public static int YViewOffset { get; set; }

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

        /// <summary>
        /// Returns the center of the player's screen view.
        /// </summary>
        /// <returns></returns>
        public static Point2D GetCameraCenter()
        {
            int x = (FullScreenWindow.Width / 2) + XViewOffset;
            int y = (FullScreenWindow.Height / 2) + YViewOffset;

            return new Point2D(x, y);
        }
    }
}