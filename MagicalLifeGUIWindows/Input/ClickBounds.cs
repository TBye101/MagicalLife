using MagicalLifeAPI.GUI;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Holds information about where a click is clicking within bounds, as well as priority and a event to subscribe to.
    /// </summary>
    public class ClickBounds
    {
        /// <summary>
        /// The range of this <see cref="ClickBounds"/> obejct.
        /// </summary>
        public Rectangle Bounds { get; set; }

        /// <summary>
        /// The priority of this click bounds.
        /// The higher the value, the higher the priority.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// The object that when this is clicked on you are interacting with.
        /// </summary>
        public Selectable GameObject { get; set; }

        /// <summary>
        /// Constructs a new instance of the <see cref="ClickBounds"/> class.
        /// </summary>
        /// <param name="startingLocation">The Point2D where this click bounds begins.</param>
        /// <param name="size">The size of this click bounds.</param>
        /// <param name="bounds"></param>
        /// <param name="priority">The priority of this click bounds. Must be equal to or greater than 0, unless this clickbounds ALWAYS has priority over other click bounds.</param>
        public ClickBounds(Rectangle bounds, int priority)
        {
            this.Bounds = bounds;
            this.Priority = priority;
        }

        /// <summary>
        /// This event is raised whenever this clickbounds is clicked on, and given priority.
        /// </summary>
        public event EventHandler<MouseEventArgs> Clicked;

        /// <summary>
        /// This event is raised whenever this clickbounds is double clicked on, and given priority.
        /// </summary>
        public event EventHandler<MouseEventArgs> DoubleClicked;

        /// <summary>
        /// Raises the <see cref="Clicked"/> event.
        /// </summary>
        /// <param name="e"></param>
        public virtual void ClickMe(MouseEventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="DoubleClicked"/> event.
        /// </summary>
        /// <param name="e"></param>
        public virtual void DoubleClickMe(MouseEventArgs e)
        {
            Clicked?.Invoke(this, e);
        }
    }
}