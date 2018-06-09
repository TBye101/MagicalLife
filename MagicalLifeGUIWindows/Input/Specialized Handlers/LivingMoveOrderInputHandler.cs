using MagicalLifeAPI.Entities;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeNetworking.Client;
using MagicalLifeNetworking.Messages;
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

            if (historical.OrderPoint != null)
            {
                foreach (Selectable item in InputHistory.Selected)
                {
                    this.Move(item, historical.OrderPoint);
                }
            }
        }

        private void Move(Selectable selectable, Microsoft.Xna.Framework.Point target)
        {
            if (World.MainWorld.Tiles[target.X, target.Y].IsWalkable)
            {
                switch (selectable)
                {
                    case Living living:

                        Microsoft.Xna.Framework.Point start = selectable.MapLocation;
                        if (start != target)
                        {
                            List<PathLink> pth = MainPathFinder.PFinder.GetRoute(World.MainWorld, living, World.MainWorld.Tiles[start.X, start.Y].Location, World.MainWorld.Tiles[target.X, target.Y].Location);

                            living.QueuedMovement.Clear();
                            Extensions.EnqueueCollection(living.QueuedMovement, pth);
                            ClientSendRecieve.Send<RouteCreatedMessage>(new RouteCreatedMessage(pth, living.ID));
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
            bool success;
            Microsoft.Xna.Framework.Point tileLocation = Util.GetMapLocation(e.Position.X, e.Position.Y, out success);

            if (success)
            {
                return World.MainWorld.Tiles[tileLocation.X, tileLocation.Y].Living;
            }
            else
            {
                return null;
            }
        }
    }
}