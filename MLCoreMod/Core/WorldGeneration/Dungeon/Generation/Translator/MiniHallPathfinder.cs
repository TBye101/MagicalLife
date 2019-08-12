using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.Components;
using MLAPI.Components.Entity;
using MLAPI.DataTypes;
using MLAPI.Filing.Logging;
using MLAPI.Pathfinding.TeleportationSearch;
using MLAPI.Util.Math;
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

        public List<Point3D> CalculateConnections(Tile tile, IWorldProvider worldProvider, Point3D origin, Point3D destination)
        {
            ComponentSelectable selectable = tile.GetExactComponent<ComponentSelectable>();
            List<Point3D> neighbors = WorldUtil.GetNonDiagonalAdjacentTiles(selectable.MapLocation, worldProvider);

            //MasterLog.DebugWriteLine("neighbors count: " + neighbors.Count);
            for (int i = neighbors.Count - 1; i > -1; i--)
            {
                //MasterLog.DebugWriteLine("Checking index: " + i);
                Point3D neighbor = neighbors[i];

                if (neighbor.Equals(destination))
                {
                    MasterLog.DebugWriteLine("Evaluating destination: " + destination);
                }

                if (!this.IsValidForPath(neighbor, worldProvider) && (!neighbor.Equals(destination) && !neighbor.Equals(origin)))
                {
                    neighbors.RemoveAt(i);
                    if (neighbor.Equals(destination))
                    {
                        MasterLog.DebugWriteLine("Removed destination: " + destination);
                    }
                }
            }

            //foreach (Point3D VARIABLE in neighbors)
            //{
            //    MasterLog.DebugWriteLine("Valid neighbor: " + VARIABLE);
            //}

            return neighbors;
        }

        private bool IsValidForPath(Point3D location, IWorldProvider worldProvider)
        {
            //MasterLog.DebugWriteLine("Checking point for path validity: " + location);

            if (worldProvider.DoesTileExist(location))
            {
                for (int i = 0; i < this.TranslationNodes.Count; i++)
                {
                    DungeonTranslationNode item = this.TranslationNodes[i];

                    //Convert offset to real tile mapping
                    int x = item.Offset.X + this.EntranceLocation.X;
                    int y = item.Offset.Y + this.EntranceLocation.Y;

                    if (Geometry.IsInRectangle(location, x, y, item.SectionWidth,
                        item.SectionHeight))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
