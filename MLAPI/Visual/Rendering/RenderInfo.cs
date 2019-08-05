using System;
using Microsoft.Xna.Framework;
using MLAPI.DataTypes;
using MLAPI.World.Base;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MLAPI.Visual.Rendering
{
    public static class RenderInfo
    {
        /// <summary>
        /// The standard size of the tiles.
        /// </summary>
        public static readonly Point TileSize = Tile.GetTileSize();

        public static Rectangle FullScreenWindow { get; set; }

        /// <summary>
        /// The standard color mask to apply to all tiles.
        /// </summary>
        public static readonly Color ColorMask = Color.White;

        /// <summary>
        /// The zoom level of the map.
        /// </summary>
        public static float Zoom { get; set; } = 1F;

        private static Guid _DimensionId;

        /// <summary>
        /// The currently viewed dimension.
        /// </summary>
        public static Guid DimensionId
        {
            get
            {
                return _DimensionId;
            }
            set
            {
                _DimensionId = value;
                Camera2D.InitializeForDimension(value);
            }
        }

        /// <summary>
        /// The game's current FPS.
        /// </summary>
        public static int GameFps { get; private set; } = 60;

        public static Camera Camera2D { get; set; } = new Camera();

        /// <summary>
        /// Returns the center of the player's screen view.
        /// </summary>
        /// <returns></returns>
        public static Point2D GetCameraCenter()
        {
            int x = (int)Camera2D.Position.X;
            int y = (int)Camera2D.Position.Y;

            return new Point2D(x, y);
        }
    }
}