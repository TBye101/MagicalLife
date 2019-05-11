using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Entity;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.Input.History;
using System.Collections.Generic;
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

        private void Move(HasComponents selectable, Point2D target)
        {
            if (World.Dimensions[RenderInfo.Dimension][target.X, target.Y].IsWalkable)
            {
                switch (selectable)
                {
                    case Living living:
                        ComponentSelectable positionData = living.GetExactComponent<ComponentSelectable>();
                        Point2D start = positionData.MapLocation;
                        if (start != target)
                        {
                            List<PathLink> pth;
                            ComponentMovement movementComponent = living.GetExactComponent<ComponentMovement>();

                            //Handle reroute
                            if (movementComponent.QueuedMovement.Count > 0)
                            {
                                //Get a path to the nearest/next tile so that path finding and the screen location sync up.
                                PathLink previous = movementComponent.QueuedMovement.Peek();
                                movementComponent.QueuedMovement.Clear();
                                movementComponent.QueuedMovement.Enqueue(previous);
                                pth = MainPathFinder.GetRoute(RenderInfo.Dimension, previous.Destination, target);
                            }
                            //No reroute
                            else
                            {
                                pth = MainPathFinder.GetRoute(RenderInfo.Dimension, positionData.MapLocation, target);
                            }

                            Extensions.EnqueueCollection(movementComponent.QueuedMovement, pth);
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}