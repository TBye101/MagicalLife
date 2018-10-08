using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Rendering.Map
{
    /// <summary>
    /// Handles rendering the map.
    /// </summary>
    public static class MapRenderer
    {
        public static MapBatch MapDrawer { get; private set; } = new MapBatch();

        /// <summary>
        /// Draws the tiles that make up the map.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawMap(SpriteBatch spBatch, int dimension)
        {
            MapDrawer.UpdateSpriteBatch(spBatch);

            foreach (Tile tile in World.Dimensions[dimension])
            {
                Point2D start = new Point2D(RenderInfo.tileSize.X * tile.MapLocation.X, RenderInfo.tileSize.Y * tile.MapLocation.Y);
                DrawTile(tile, start);
            }

            DrawEntities(dimension);
        }

        public static void DrawEntities(int dimension)
        {
            int chunkHeight = Chunk.Height;
            int chunkWidth = Chunk.Width;
            int xSize = World.Dimensions[dimension].Width;
            int ySize = World.Dimensions[dimension].Height;

            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    Chunk chunk = World.Dimensions[dimension].GetChunk(x, y);

                    foreach (KeyValuePair<System.Guid, Living> item in chunk.Creatures)
                    {
                        if (item.Value != null)
                        {
                            Texture2D livingTexture = AssetManager.Textures[AssetManager.GetTextureIndex(item.Value.GetTextureName())];
                            Vector2 livingScreenLocation = new Vector2(item.Value.ScreenLocation.X * Tile.GetTileSize().X, item.Value.ScreenLocation.Y * Tile.GetTileSize().Y);
                            MapDrawer.Draw(livingTexture, livingScreenLocation);
                            //TODO: Fix above line
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Draws a tile.
        /// </summary>
        private static void DrawTile(Tile tile, Point2D start)
        {

            Microsoft.Xna.Framework.Rectangle target = new Microsoft.Xna.Framework.Rectangle(start, RenderInfo.tileSize);

            //A target location for 32x textures to be centered in the tile, without being enlarged.
            Rectangle x32Target = new Rectangle(start.X + 16, start.Y + 16, 32, 32);

            tile.CompositeRenderer.Render(MapDrawer, start);

            //MapDrawer.Draw(AssetManager.Textures[tile.GetRenderable().TextureID], target);

            //DrawStone(tile, target);
            //DrawItems(tile, target);

            if (tile.ImpendingAction == MagicalLifeAPI.Entity.AI.Task.ActionSelected.Mine)
            {
                MapDrawer.Draw(AssetManager.Textures[AssetManager.NameToIndex["PickaxeMapIcon"]], x32Target);
            }
        }

        //private static void DrawItems(Tile tile, Rectangle target)
        //{
        //    if (tile.Item != null)
        //    {
        //        Texture2D texture = AssetManager.Textures[tile.Item.TextureIndex];
        //        MapDrawer.Draw(texture, target);
        //    }
        //}

        /// <summary>
        /// Draws stone if it is present in the tile.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="spBatch"></param>
        /// <param name="target"></param>
        //private static void DrawStone(Tile tile, Rectangle target)
        //{
        //    if (tile.Resources != null)
        //    {
        //        switch (tile.Resources)
        //        {
        //            case StoneBase stone:
        //                Texture2D stoneTexture = AssetManager.Textures[AssetManager.GetTextureIndex(stone.GetUnconnectedTexture())];
        //                MapDrawer.Draw(stoneTexture, target);
        //                break;

        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}