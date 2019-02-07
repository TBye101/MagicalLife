using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeGUIWindows.Rendering.Map
{
    /// <summary>
    /// Handles rendering the map.
    /// </summary>
    public static class MapRenderer
    {
        public static MapBatch MapDrawer { get; private set; } = new MapBatch();

        private static SpriteFont ItemCountFont { get; set; } = Game1.AssetManager.Load<SpriteFont>(TextureLoader.FontMainMenuFont12x);

        private static MapCuller Culler = new MapCuller();

        private static Point2D TileSize = Tile.GetTileSize();

        /// <summary>
        /// Draws the tiles that make up the map.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawMap(SpriteBatch spBatch, int dimension)
        {
            MapDrawer.UpdateSpriteBatch(spBatch);

            Point2D[,] result = Culler.GetChunksInView(RenderInfo.XViewOffset, RenderInfo.YViewOffset, RenderInfo.FullScreenWindow);

            //Iterates over all the chunks that are within view of the client's screen.
            int width = result.GetLength(0);
            int height = result.GetLength(1);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Point2D chunkCoordinates = result[x, y];
                    Chunk chunk = World.GetChunk(dimension, chunkCoordinates.X, chunkCoordinates.Y);

                    foreach (Tile tile in chunk)
                    {
                        Point2D start = new Point2D(RenderInfo.tileSize.X * tile.MapLocation.X, RenderInfo.tileSize.Y * tile.MapLocation.Y);
                        DrawTile(tile, start);
                    }

                    DrawEntities(dimension, chunk);
                }
            }
        }

        public static void DrawEntities(int dimension, Chunk chunk)
        {
            int length = chunk.Creatures.Count;
            for (int i = 0; i < length; i++)
            {
                KeyValuePair<System.Guid, Living> item = chunk.Creatures.ElementAt(i);
                if (item.Value != null)
                {
                    Point2D livingScreenLocation = new Point2D((int)(item.Value.TileLocation.X * TileSize.X), (int)(item.Value.TileLocation.Y * TileSize.Y));
                    item.Value.Visual.Render(MapDrawer, livingScreenLocation);
                }
            }
        }

        private static void DrawItems(Tile tile, Rectangle target)
        {
            if (tile.Item != null)
            {
                Texture2D texture = AssetManager.Textures[tile.Item.TextureIndex];
                MapDrawer.Draw(texture, target, RenderLayer.Items);

                Rectangle itemCountBounds = new Rectangle(target.Location.X + TileSize.X / 2, target.Location.Y + TileSize.Y, 32, 8);
                MapDrawer.DrawText(tile.Item.CurrentlyStacked.ToString(), itemCountBounds,
                    ItemCountFont, SimpleTextRenderer.Alignment.Left, RenderLayer.MapItemCount);
            }
        }

        /// <summary>
        /// Draws a tile.
        /// </summary>
        private static void DrawTile(Tile tile, Point2D start)
        {
            //A target location for 32x textures to be centered in the tile, without being enlarged.
            Rectangle x32Target = new Rectangle(start.X + 16, start.Y + 16, 32, 32);

            tile.CompositeRenderer.Render(MapDrawer, start);
            DrawItems(tile, new Rectangle(start.X, start.Y, TileSize.X, TileSize.Y));

            switch (tile.ImpendingAction)
            {
                case MagicalLifeAPI.Entity.AI.Task.ActionSelected.Mine:
                    MapDrawer.Draw(AssetManager.Textures[AssetManager.NameToIndex[TextureLoader.GUIPickaxeMapIcon]], x32Target, RenderLayer.GUI);
                    break;

                case MagicalLifeAPI.Entity.AI.Task.ActionSelected.Chop:
                    MapDrawer.Draw(AssetManager.Textures[AssetManager.NameToIndex[TextureLoader.GUIAxeMapIcon]], x32Target, RenderLayer.GUI);
                    break;

                default:
                    //Do nothing.
                    break;
            }
        }
    }
}