using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Entity;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.MAP_GUI;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Registry.WorldGeneration;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.Input.History;
using System;
using System.Linq;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    /// <summary>
    /// Used to check if the correct sequence of events has occurred to order a <see cref="Living"/> to move.
    /// If the sequence occurs, this class orders the move.
    /// </summary>
    public class LivingMoveOrderInputHandler
    {
        public LivingMoveOrderInputHandler()
        {
            InputHistory.InputAdded += this.InputHistory_InputAdded;
        }

        private void InputHistory_InputAdded()
        {
            HistoricalInput historical = InputHistory.History.Last();

            if (historical.ActionSelected == ActionSelected.None && historical.OrderedToTile && historical.OrderPoint2D != null)
            {
                foreach (HasComponents item in InputHistory.Selected)
                {
                    this.Move(item, historical.OrderPoint2D);
                }
            }
        }

        private void Move(HasComponents selectable, Point3D target)
        {
            if (World.Dimensions[RenderInfo.DimensionID][target.X, target.Y].IsWalkable)
            {
                switch (selectable)
                {
                    case Living living:
                        ComponentSelectable positionData = living.GetExactComponent<ComponentSelectable>();
                        Point3D start = positionData.MapLocation;
                        if (start != target)
                        {
                            ComponentMovement movementComponent = living.GetExactComponent<ComponentMovement>();

                            //Handle reroute
                            if (movementComponent.QueuedMovement.Count > 0)
                            {
                                //Get a path to the nearest/next tile so that path finding and the screen location sync up.
                                PathLink previous = movementComponent.QueuedMovement.Peek();
                                movementComponent.QueuedMovement.Clear();
                                movementComponent.QueuedMovement.Enqueue(previous);
                                this.HandleOrder(living, target, previous.Destination);
                            }
                            //No reroute
                            else
                            {
                                this.HandleOrder(living, target, positionData.MapLocation);
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private void HandleOrder(Living living, Point3D target, Point3D start)
        {
            Tile tile = World.GetTile(target);

            if (tile.MainObject != null)
            {
                PortalComponent portalComponent = tile.MainObject.GetComponent<PortalComponent>();

                if (portalComponent != null)
                {
                    Point3D connection = portalComponent.Connections[0];

                    if (!World.Dimensions.ContainsKey(connection.DimensionID))
                    {
                        //Need to generate the dungeon first.
                        DungeonGenerator generator = WorldGeneratorRegistry.DungeonGenerators.GetRandomItem();
                        ProtoArray<Chunk> generated = generator.Generate(25, 25, "Dungeon", new System.Random(1020239), connection.DimensionID, connection, target);
                        Dimension dim = new Dimension("Dungeon", generated, connection.DimensionID);
                        RenderInfo.DimensionID = connection.DimensionID;
                    }

                    MainPathFinder.GiveRouteAsync(living, start, connection);
                }
                else
                {
                    MainPathFinder.GiveRouteAsync(living, start, target);
                }
            }
            else
            {
                MainPathFinder.GiveRouteAsync(living, start, target);
            }
        }
    }
}