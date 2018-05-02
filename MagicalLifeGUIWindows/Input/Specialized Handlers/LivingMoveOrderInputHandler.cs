using MagicalLifeAPI.Entities;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeGUIWindows.Input.History;
using MonoGame.Extended.Input.InputListeners;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    /// <summary>
    /// Used to check if the correct sequence of events has occured to order a <see cref="Living"/> to move.
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
            if (World.mainWorld.Tiles[target.X, target.Y].IsWalkable)
            {
                switch (selectable)
                {
                    case Living living:

                        Microsoft.Xna.Framework.Point start = selectable.MapLocation;
                        if (start != target)
                        {
                            List<PathLink> pth = MainPathFinder.PFinder.GetRoute(World.mainWorld, living, World.mainWorld.Tiles[start.X, start.Y].Location, World.mainWorld.Tiles[target.X, target.Y].Location);

                            living.QueuedMovement.Clear();
                            Extensions.EnqueueCollection(living.QueuedMovement, pth);
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
            Microsoft.Xna.Framework.Point tileLocation = Util.GetMapLocation(e.Position.X, e.Position.Y);
            return World.mainWorld.Tiles[tileLocation.X, tileLocation.Y].Living;
        }
    }
}