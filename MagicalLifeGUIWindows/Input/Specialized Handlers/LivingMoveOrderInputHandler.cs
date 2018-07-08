using MagicalLifeAPI.Entities;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeGUIWindows.Rendering;
using MonoGame.Extended.Input.InputListeners;
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

            if (historical.OrderedToTile && historical.OrderPoint != null)
            {
                foreach (Selectable item in InputHistory.Selected)
                {
                    this.Move(item, historical.OrderPoint);
                }
            }
        }

        private void Move(Selectable selectable, Microsoft.Xna.Framework.Point target)
        {
            if (World.Dimensions[RenderingPipe.Dimension][target.X, target.Y].IsWalkable)
            {
                switch (selectable)
                {
                    case Living living:

                        Microsoft.Xna.Framework.Point start = selectable.MapLocation;
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
                                pth = MainPathFinder.GetRoute(RenderingPipe.Dimension, previous.Destination, target);
                            }
                            //No reroute
                            else
                            {
                                pth = MainPathFinder.GetRoute(RenderingPipe.Dimension, living.MapLocation, target);
                            }

                            Extensions.EnqueueCollection(living.QueuedMovement, pth);
                            ClientSendRecieve.Send<RouteCreatedMessage>(new RouteCreatedMessage(pth, living.ID, living.Dimension));
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Returns all living creatures at the specified screen position.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private Living GetLivingAtClick(MouseEventArgs e)
        {
            Microsoft.Xna.Framework.Point tileLocation = Util.GetMapLocation(e.Position.X, e.Position.Y, RenderingPipe.Dimension, out bool success);

            if (success)
            {
                Chunk chunk = World.Dimensions[RenderingPipe.Dimension].GetChunkForLocation(tileLocation.X, tileLocation.Y);

                foreach (Living item in chunk.Creatures)
                {
                    if (item.MapLocation == tileLocation)
                    {
                        return item;
                    }
                }
            }

            return null;
        }
    }
}