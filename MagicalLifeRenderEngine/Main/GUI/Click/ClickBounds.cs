using MagicalLifeAPI.Universal;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeRenderEngine.Main.GUI.Click
{
    /// <summary>
    /// Holds information about where a click is clicking within bounds, as well as priority and a event to subscribe to.
    /// </summary>
    public class ClickBounds : Unique
    {
        /// <summary>
        /// The point where this click bounds begins.
        /// </summary>
        public Point StartingLocation { get; set; }

        /// <summary>
        /// The size of this click bounds.
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// The priority of this click bounds.
        /// Must be equal to or greater than 0, unless this clickbounds ALWAYS has priority over other click bounds.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Constructs a new instance of the <see cref="ClickBounds"/> class.
        /// </summary>
        /// <param name="startingLocation">The point where this click bounds begins.</param>
        /// <param name="size">The size of this click bounds.</param>
        /// <param name="priority">The priority of this click bounds. Must be equal to or greater than 0, unless this clickbounds ALWAYS has priority over other click bounds.</param>
        public ClickBounds(Point startingLocation, Size size, int priority)
        {
            this.StartingLocation = startingLocation;
            this.Size = size;
            this.Priority = priority;
        }

        /// <summary>
        /// This event is raised whenever this clickbounds is clicked on, and given priority.
        /// </summary>
        public event EventHandler<Point> Clicked;

        /// <summary>
        /// Raises the Clicked event.
        /// </summary>
        /// <param name="e"></param>
        public virtual void ClickMe(Point e)
        {
            EventHandler<Point> handler = Clicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
