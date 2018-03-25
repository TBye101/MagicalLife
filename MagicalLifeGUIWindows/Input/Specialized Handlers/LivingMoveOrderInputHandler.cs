using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.World;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    /// <summary>
    /// Used to check if the correct sequence of events has occured to order a <see cref="Living"/> to move.
    /// If the sequence occurs, this class orders the move.
    /// </summary>
    public class LivingMoveOrderInputHandler
    {
        private Living Selected = null;

        public LivingMoveOrderInputHandler()
        {
            BoundHandler.MouseListner.MouseClicked += this.MouseListner_MouseClicked;
        }

        private void MouseListner_MouseClicked(object sender, MonoGame.Extended.Input.InputListeners.MouseEventArgs e)
        {
            if (e.Button == MouseButton.Left)
            {
                Living livings = GetLivingAtClick(e);

                if (livings != null)
                {
                    this.Selected = livings;//have a history of input, then do a strategy pattern to decide what happens based on that.
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
            Point3D tileLocation = Util.GetMapLocation(e.Position.X, e.Position.Y);
            return World.mainWorld.Tiles[tileLocation.X, tileLocation.Y, tileLocation.Z].Living;
        }
    }
}
