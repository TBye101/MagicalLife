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
                foreach (Selectable item in InputHistory.Selected)
                {
                    this.Move(item, historical.OrderPoint2D);
                }
            }
        }

        private void Move(Selectable selectable, Point2D target)
        {
            if (World.Dimensions[RenderInfo.Dimension][target.X, target.Y].IsWalkable)
            {
                switch (selectable)
                {
                    case Living living:

                        Point2D start = selectable.MapLocation;
                        if (start != target)
                        {
                            List<PathLink> pth;

                            //Handle reroute
                            if (living.QueuedMovement.Count > 0)
                            {
                                //Get a path to the nearest/next tile so that path finding and the screen location sync up.
                                PathLink previous = living.QueuedMovement.Peek();
                                living.QueuedMovement.Clear();
                                living.QueuedMovement.Enqueue(previous);
                                pth = MainPathFinder.GetRoute(RenderInfo.Dimension, previous.Destination, target);
                            }
                            //No reroute
                            else
                            {
                                pth = MainPathFinder.GetRoute(RenderInfo.Dimension, living.MapLocation, target);
                            }

                            Extensions.EnqueueCollection(living.QueuedMovement, pth);
                            //ClientSendRecieve.Send<RouteCreatedMessage>(new RouteCreatedMessage(pth, living.ID, living.Dimension));
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}