using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    /// <summary>
    /// Handles GUI containers being dragged. 
    /// </summary>
    public class ContainerDragHandler
    {
        public ContainerDragHandler()
        {
            BoundHandler.MouseListner.MouseDrag += this.MouseListner_MouseDrag;
        }

        private void MouseListner_MouseDrag(object sender, MonoGame.Extended.Input.InputListeners.MouseEventArgs e)
        {
            List<GUIContainer> windows = BoundHandler.GUIWindows.FindAll(
                x => x.DrawingBounds.Contains(e.Position.X, e.Position.Y)
                && x.DrawingBounds.Y - 40 < e.Position.Y);

            if (windows.Count > 0)
            {
                GUIContainer windowToMove = this.GetHighestPriority(windows);

                Rectangle newPosition = new Rectangle(
                    new Point((int)(e.Position.X + e.DistanceMoved.X), 
                    (int)(e.Position.Y + e.DistanceMoved.Y)), windowToMove.DrawingBounds.Size);

                windowToMove.DrawingBounds = newPosition;
            }
        }

        /// <summary>
        /// Gets the highest priority GUI container from the list.
        /// </summary>
        /// <param name="containers"></param>
        /// <returns></returns>
        private GUIContainer GetHighestPriority(List<GUIContainer> containers)
        {
            while (containers.Count > 1)
            {
                if (containers[0].Priority > containers[1].Priority)
                {
                    containers.RemoveAt(1);
                }
                else
                {
                    containers.RemoveAt(0);
                }
            }

            return containers[0];
        }
    }
}
