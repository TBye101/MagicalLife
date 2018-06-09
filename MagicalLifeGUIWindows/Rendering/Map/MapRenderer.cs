using MagicalLifeAPI.Asset;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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
            ProtoArray<Tile> tiles = World.MainWorld.Tiles;

            int xSize = tiles.Width;
            int ySize = tiles.Height;
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
                //tile.Living.ScreenLocation
                Texture2D livingTexture = AssetManager.Textures[AssetManager.GetTextureIndex(tile.Living.GetTextureName())];
                Vector2 livingScreenLocation = new Vector2(tile.Living.ScreenLocation.X * Tile.GetTileSize().X, tile.Living.ScreenLocation.Y * Tile.GetTileSize().Y);
                spBatch.Draw(livingTexture, livingScreenLocation, RenderingPipe.colorMask);
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
            if (tile.Resources != null)
            {
                switch (tile.Resources)
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