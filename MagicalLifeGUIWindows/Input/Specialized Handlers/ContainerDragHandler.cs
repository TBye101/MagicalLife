using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

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
        private bool StillDraggingLast;

        public ContainerDragHandler()
        {
            BoundHandler.MouseListener.MouseDragStart += this.MouseListner_MouseDragStart;
            BoundHandler.MouseListener.MouseDrag += this.MouseListner_MouseDrag;
            BoundHandler.MouseListener.MouseDragEnd += this.MouseListner_MouseDragEnd;
        }

        private void MouseListner_MouseDragEnd(object sender, MonoGame.Extended.Input.InputListeners.MouseEventArgs e)
        {
            this.StillDraggingLast = false;
        }

        private void MouseListner_MouseDragStart(object sender, MonoGame.Extended.Input.InputListeners.MouseEventArgs e)
        {
            List<GUIContainer> windows = new List<GUIContainer>();

            foreach (GUIContainer item in BoundHandler.GUIWindows)
            {
                //If the container contains the mouse position
                if (item.DrawingBounds.Contains(e.Position.X, e.Position.Y))
                {
                    //If the mouse position is within the drag zone
                    if (item.DrawingBounds.Y - 40 < e.Position.Y)
                    {
                        //If the GUI is dragable
                        if (item.IsMovable)
                        {
                            windows.Add(item);
                        }
                    }
                }
            }

            if (windows.Count > 0)
            {
                GUIContainer windowToMove = this.GetHighestPriority(windows);
                this.LastDragged = windowToMove;
                this.StillDraggingLast = true;
            }
        }

        private void MouseListner_MouseDrag(object sender, MonoGame.Extended.Input.InputListeners.MouseEventArgs e)
        {
            if (this.StillDraggingLast)
            {
                int newX = this.LastDragged.DrawingBounds.X + (int)e.DistanceMoved.X;
                int newY = this.LastDragged.DrawingBounds.Y + (int)e.DistanceMoved.Y;
                Point position = new Point(newX, newY);
                Rectangle newPosition = new Rectangle(position, this.LastDragged.DrawingBounds.Size);

                this.LastDragged.DrawingBounds = newPosition;
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