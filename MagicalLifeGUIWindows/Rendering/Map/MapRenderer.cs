using MagicalLifeAPI.Asset;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Rendering.Map
{
    /// <summary>
    /// Handles rendering the map.
    /// </summary>
    public static class MapRenderer
    {
        /// <summary>
        /// Draws the tiles that make up the map.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawMap(ref SpriteBatch spBatch)
        {
            Tile[,] tiles = World.mainWorld.Tiles;

            int xSize = tiles.GetLength(0);
            int ySize = tiles.GetLength(1);
            int x = 0;
            int y = 0;

            while (x < xSize)
            {
                while (y < ySize)
                {
                    Tile tile = tiles[x, y];
                    Microsoft.Xna.Framework.Point start = new Microsoft.Xna.Framework.Point(RenderingPipe.tileSize.X * x, RenderingPipe.tileSize.Y * y);
                    DrawTile(tile, ref spBatch, start);
                    y++;
                }
                y = 0;
                x++;
            }
        }

        /// <summary>
        /// Draws a tile.
        /// </summary>
        private static void DrawTile(Tile tile, ref SpriteBatch spBatch, Point start)
        {
            Microsoft.Xna.Framework.Rectangle target = new Microsoft.Xna.Framework.Rectangle(start, RenderingPipe.tileSize);
            spBatch.Draw(AssetManager.Textures[tile.TextureIndex], target, RenderingPipe.colorMask);

            DrawStone(tile, ref spBatch, target);

            if (tile.Living != null)
            {
                Texture2D livingTexture = AssetManager.Textures[AssetManager.GetTextureIndex(tile.Living.GetTextureName())];
                spBatch.Draw(livingTexture, target, RenderingPipe.colorMask);
            }
        }

        /// <summary>
        /// Draws stone if it is present in the tile.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="spBatch"></param>
        /// <param name="target"></param>
        private static void DrawStone(Tile tile, ref SpriteBatch spBatch, Rectangle target)
        {
            if (tile.Resources.Count > 0)
            {
                switch (tile.Resources[0])
                {
                    case StoneBase stone:
                        Texture2D stoneTexture = AssetManager.Textures[AssetManager.GetTextureIndex(stone.GetUnconnectedTexture())];
                        spBatch.Draw(stoneTexture, target, RenderingPipe.colorMask);
                        break;
                }
            }
        }
    }
}
