using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using MLAPI.Asset;
using MLAPI.Components;
using MLAPI.Components.Entity;
using MLAPI.DataTypes;
using MLAPI.Entity;
using MLAPI.Entity.AI.Task;
using MLAPI.Visual;
using MLAPI.Visual.Rendering;
using MLAPI.Visual.Rendering.Map;
using MLAPI.World.Base;
using MLAPI.World.Data;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MLGUIWindows.Rendering.Map
{
    /// <summary>
    /// Handles rendering the map.
    /// </summary>
    public static class MapRenderer
    {
        public static MapBatch MapDrawer { get; private set; } = new MapBatch();

        private static SpriteFont ItemCountFont { get; set; } = Game1.AssetManager.Load<SpriteFont>(TextureLoader.FontMainMenuFont12X);

        private static MapCuller Culler = new MapCuller(RenderInfo.FullScreenWindow);

        private static Point2D TileSize = Tile.GetTileSize();

        /// <summary>
        /// The starting point of a tile, a reused Point2D.
        /// </summary>
        private static Point2D StartingPoint = new Point2D(0, 0);

        /// <summary>
        /// The location of an entity on screen. A reused Point2D.
        /// </summary>
        private static Point2D LivingScreenLocation = new Point2D(0, 0);

        /// <summary>
        /// A reused Rectangle for the location of the item count.
        /// </summary>
        private static Rectangle ItemCountBounds = new Rectangle(0, 0, 32, 8);

        /// <summary>
        /// A reused Rectangle for centering on a tile.
        /// </summary>
        private static Rectangle X32Target = new Rectangle(0, 0, 32, 32);

        /// <summary>
        /// A reused rectangle for the location of a tile.
        /// </summary>
        private static Rectangle TileItemTarget = new Rectangle(0, 0, TileSize.X, TileSize.Y);

        /// <summary>
        /// Draws the tiles that make up the map.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawMap(SpriteBatch spBatch, Guid dimensionId)
        {
            MapDrawer.UpdateSpriteBatch(spBatch);
            List<Point2D> result = Culler.GetChunksInView();

            //Iterates over all the chunks that are within view of the client's screen.
            int length = result.Count;

            for (int i = 0; i < length; i++)
            {
                Point2D chunkCoordinates = result[i];

                if (chunkCoordinates.X != -1 && chunkCoordinates.Y != -1)
                {
                    Chunk chunk = World.GetChunk(dimensionId, chunkCoordinates.X, chunkCoordinates.Y);
                    RenderChunk(chunk, dimensionId);
                }
            }

            MapDrawer.RenderAll();
        }

        private static void RenderChunk(Chunk chunk, Guid dimensionId)
        {
            foreach (Tile tile in chunk)
            {
                ComponentSelectable selectable = tile.GetExactComponent<ComponentSelectable>();
                StartingPoint.X = RenderInfo.TileSize.X * selectable.MapLocation.X;
                StartingPoint.Y = RenderInfo.TileSize.Y * selectable.MapLocation.Y;
                DrawTile(tile, StartingPoint);
            }

            DrawEntities(chunk);
        }

        /// <summary>
        /// Draws the entities.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="chunk">The chunk.</param>
        public static void DrawEntities(Chunk chunk)
        {
            int length = chunk.Creatures.Count;
            lock (chunk.Creatures)
            {
                for (int i = 0; i < length; i++)
                {
                    KeyValuePair<System.Guid, Living> item = chunk.Creatures.ElementAt(i);
                    if (item.Value != null)
                    {
                        ComponentMovement movementComponent = item.Value.GetExactComponent<ComponentMovement>();
                        LivingScreenLocation.X = (int)(movementComponent.TileLocation.X * TileSize.X);
                        LivingScreenLocation.Y = (int)(movementComponent.TileLocation.Y * TileSize.Y);
                        item.Value.Visual.Render(MapDrawer, LivingScreenLocation);
                    }
                }
            }
        }

        private static void DrawItems(Tile tile, Rectangle target)
        {
            Item tileItem = tile.MainObject as Item;
            if (tileItem != null)
            {
                ComponentHasTexture itemVisual = tileItem.GetExactComponent<ComponentHasTexture>();

                Point2D topLeft = new Point2D(0, 0);
                int length = itemVisual.Visuals.Count;
                for (int i = 0; i < length; i++)
                {
                    AbstractVisual visual = itemVisual.Visuals[i];
                    topLeft.X = target.X;
                    topLeft.Y = target.Y;
                    visual.Render(MapDrawer, topLeft);
                }

                ItemCountBounds.X = target.Location.X + (TileSize.X / 2);
                ItemCountBounds.Y = target.Location.Y + TileSize.Y;

                MapDrawer.DrawText(tileItem.CurrentlyStacked.ToString(), ItemCountBounds,
                    ItemCountFont, SimpleTextRenderer.Alignment.Left, RenderLayer.MapItemCount);
            }
        }

        /// <summary>
        /// Draws a tile.
        /// </summary>
        private static void DrawTile(Tile tile, Point2D start)
        {
            //A target location for 32x textures to be centered in the tile, without being enlarged.
            X32Target.X = start.X + 16;
            X32Target.Y = start.Y + 16;

            ComponentRenderer tileRenderer = tile.GetComponent<ComponentRenderer>();
            tileRenderer.Render(MapDrawer, start);

            TileItemTarget.X = start.X;
            TileItemTarget.Y = start.Y;

            DrawItems(tile, TileItemTarget);

            switch (tile.ImpendingAction)
            {
                case ActionSelected.Mine:
                    MapDrawer.Draw(AssetManager.Textures[AssetManager.NameToIndex[TextureLoader.GuiPickaxeMapIcon]], X32Target, RenderLayer.Gui);
                    break;

                case ActionSelected.Chop:
                    MapDrawer.Draw(AssetManager.Textures[AssetManager.NameToIndex[TextureLoader.GuiAxeMapIcon]], X32Target, RenderLayer.Gui);
                    break;

                default:
                    //Do nothing.
                    break;
            }
        }
    }
}