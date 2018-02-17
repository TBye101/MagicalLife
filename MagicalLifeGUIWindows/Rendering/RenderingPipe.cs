using System.Drawing;
using Microsoft.Xna.Framework;
using MagicalLifeGUIWindows.Asset;
using MagicalLifeAPI.World;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Rendering
{
    /// <summary>
    /// Handles drawing the entire screen.
    /// </summary>
    public static class RenderingPipe
    {
        /// <summary>
        /// The standard size of the tiles.
        /// </summary>
        private static readonly Microsoft.Xna.Framework.Point tileSize = Tile.GetTileSize();

        /// <summary>
        /// The standard color mask to apply to all tiles.
        /// </summary>
        private static readonly Microsoft.Xna.Framework.Color colorMask = new Microsoft.Xna.Framework.Color();

        /// <summary>
        /// Draws the screen.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawScreen(ref SpriteBatch spBatch)
        {
            if (World.mainWorld != null)
            {
                DrawMap(ref spBatch);
                DrawGUI(ref spBatch);
            }
        }

        /// <summary>
        /// Draws the GUI onto the screen.
        /// </summary>
        /// <param name="spBatch"></param>
        private static void DrawGUI(ref SpriteBatch spBatch)
        {

        }

        /// <summary>
        /// Draws the tiles that make up the map.
        /// </summary>
        /// <param name="spBatch"></param>
        private static void DrawMap(ref SpriteBatch spBatch)
        {
            Tile[,,] tiles = World.mainWorld.Tiles;

            int xSize = tiles.GetLength(0);
            int ySize = tiles.GetLength(1);
            int zSize = tiles.GetLength(2);
            int x = 0;
            int y = 0;
            int z = 0;

            while (x < xSize)
            {
                while (y < ySize)
                {
                    while (z < zSize)
                    {
                        Tile tile = tiles[x, y, z];
                        Microsoft.Xna.Framework.Point start = new Microsoft.Xna.Framework.Point(tileSize.X * x, tileSize.Y * y);
                        Microsoft.Xna.Framework.Rectangle target = new Microsoft.Xna.Framework.Rectangle(start, tileSize);
                        spBatch.Draw(AssetManager.Textures[tile.TextureIndex], target, colorMask);
                        z++;
                    }
                    z = 0;
                    y++;
                }
                y = 0;
                x++;
            }
        }
    }
}
