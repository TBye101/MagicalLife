using MagicalLifeAPI.Asset;
using MagicalLifeAPI.World;
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
                        Microsoft.Xna.Framework.Point start = new Microsoft.Xna.Framework.Point(RenderingPipe.tileSize.X * x, RenderingPipe.tileSize.Y * y);
                        DrawTile(tile, ref spBatch, start);
                        z++;
                    }
                    z = 0;
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

            if (tile.Living.Count > 0)
            {
                Texture2D livingTexture = AssetManager.Textures[AssetManager.GetTextureIndex(tile.Living[tile.Living.Count - 1].GetTextureName())];
                spBatch.Draw(livingTexture, target, RenderingPipe.colorMask);
            }
        }
    }
}
