using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.Components;
using MLAPI.Components.Entity;
using MLAPI.DataTypes;
using MLAPI.Pathfinding.TeleportationSearch;
using MLAPI.World;
using MLAPI.World.Base;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator
{
    /// <summary>
    /// Used to pathfind routes for small hallways between dungeon rooms.
    /// </summary>
    public class MiniHallPathfinder : IConnectionProvider
    {
        private readonly List<DungeonTranslationNode> TranslationNodes;
        private readonly Point2D EntranceLocation;

        public MiniHallPathfinder(List<DungeonTranslationNode> translationNodes, Point2D entranceLocation)
        {
            this.TranslationNodes = translationNodes;
            this.EntranceLocation = entranceLocation;
        }

        public List<Point3D> CalculateConnections(Tile tile)
        {
            ComponentSelectable selectable = tile.GetExactComponent<ComponentSelectable>();
            List<Point3D> neighbors = WorldUtil.GetNeighboringTiles(selectable.MapLocation);

            for (int i = neighbors.Count - 1; i > -1; i--)
            {
                if (!this.IsValidForPath(neighbors[i]))
                {
                    neighbors.RemoveAt(i);
                }
            }

            return neighbors;
        }

        private bool IsValidForPath(Point3D location)
        {
            for (int i = 0; i < this.TranslationNodes.Count; i++)
            {
                DungeonTranslationNode item = this.TranslationNodes[i];

                //Convert offset to real tile mapping
                int x = item.Offset.X + this.EntranceLocation.X;
                int y = item.Offset.Y + this.EntranceLocation.Y;

                if (this.IsInOrAdjacentToRectangle(location, x, y, item.SectionWidth,
                    item.SectionHeight))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsInOrAdjacentToRectangle(Point2D location, int rectangleX, int rectangleY, int rectangleWidth, int rectangleHeight)
        {
            return (location.X >= (rectangleX - 1) && location.X <= (rectangleX + rectangleWidth + 1)) &&
                   (location.Y >= (rectangleY - 1) && location.Y <= (rectangleY + rectangleHeight + 1));
        }
    }
}
