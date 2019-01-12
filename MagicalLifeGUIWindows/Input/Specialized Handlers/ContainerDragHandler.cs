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
        /// <summary>
        /// The last dragged GUI window.
        /// </summary>
        private GUIContainer LastDragged;

        /// <summary>
        /// If true, the last dragged window is still being dragged.
        /// </summary>
        private bool StillDraggingLast = false;

        public ContainerDragHandler()
        {
            BoundHandler.MouseListner.MouseDragStart += this.MouseListner_MouseDragStart;
            BoundHandler.MouseListner.MouseDrag += this.MouseListner_MouseDrag;
            BoundHandler.MouseListner.MouseDragEnd += this.MouseListner_MouseDragEnd;
        }

        private void MouseListner_MouseDragEnd(object sender, MonoGame.Extended.Input.InputListeners.MouseEventArgs e)
        {
            this.StillDraggingLast = false;
        }

        private void MouseListner_MouseDragStart(object sender, MonoGame.Extended.Input.InputListeners.MouseEventArgs e)
        {
            List<GUIContainer> windows = BoundHandler.GUIWindows.FindAll(
                x => x.DrawingBounds.Contains(e.Position.X, e.Position.Y)
                && x.DrawingBounds.Y - 40 < e.Position.Y
                && x.IsMovable);

            if (windows.Count > 0)
            {
                GUIContainer windowToMove = this.GetHighestPriority(windows);
                this.LastDragged = windowToMove;
                this.StillDraggingLast = true;

                Rectangle newPosition = new Rectangle(
                    new Point((int)(e.Position.X + e.DistanceMoved.X),
                    (int)(e.Position.Y + e.DistanceMoved.Y)), windowToMove.DrawingBounds.Size);

                windowToMove.DrawingBounds = newPosition;
                windowToMove.AdjustClickBounds((int)e.DistanceMoved.X, (int)e.DistanceMoved.Y);
            }
        }

        private void MouseListner_MouseDrag(object sender, MonoGame.Extended.Input.InputListeners.MouseEventArgs e)
        {
            if (StillDraggingLast)
            {
                Rectangle newPosition = new Rectangle(
                    new Point((int)(e.Position.X + e.DistanceMoved.X),
                    (int)(e.Position.Y + e.DistanceMoved.Y)), this.LastDragged.DrawingBounds.Size);

                this.LastDragged.DrawingBounds = newPosition;
                this.LastDragged.AdjustClickBounds((int)e.DistanceMoved.X, (int)e.DistanceMoved.Y);
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
