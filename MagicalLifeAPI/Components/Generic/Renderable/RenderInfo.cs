using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    public static class RenderInfo
    {
        /// <summary>
        /// The standard size of the tiles.
        /// </summary>
        public static readonly Point tileSize = MagicalLifeAPI.World.Base.Tile.GetTileSize();

        public static readonly Rectangle FullScreenWindow = new Rectangle(new Point(0, 0), new Point(MagicalLifeSettings.Storage.MainWindow.Default.ScreenSize.Width, MagicalLifeSettings.Storage.MainWindow.Default.ScreenSize.Height));

        /// <summary>
        /// The standard color mask to apply to all tiles.
        /// </summary>
        public static readonly Color colorMask = Color.White;

        /// <summary>
        /// The x offset of the view due to the player moving the camera around the map.
        /// </summary>
        public static int XViewOffset { get; set; } = 0;

        /// <summary>
        /// The y offset of the view due to the player moving the camera around the map.
        /// </summary>
        public static int YViewOffset { get; set; } = 0;

        /// <summary>
        /// The zoom level of the map.
        /// </summary>
        public static float Zoom { get; set; } = 1F;

        /// <summary>
        /// The currently viewed dimension.
        /// </summary>
        public static int Dimension { get; set; } = 0;
    }
}
