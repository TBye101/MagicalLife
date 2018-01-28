using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeRenderEngine.Main.GUI.Click
{
    /// <summary>
    /// Determines who is being clicked on when the user clicks.
    /// </summary>
    public static class ClickDistributor
    {
        /// <summary>
        /// Contains all of the ClickBounds this class handles.
        /// </summary>
        private static SortedSet<ClickBounds> Bounds = new SortedSet<ClickBounds>(new BoundsSorter());

        /// <summary>
        /// Adds a <see cref="ClickBounds"/> object to the system to be handled.
        /// </summary>
        /// <param name="bounds"></param>
        public static void AddClickBounds(ClickBounds bounds)
        {
            Bounds.Add(bounds);
        }

        /// <summary>
        /// Removes a <see cref="ClickBounds"/> object by ID.
        /// </summary>
        /// <param name="boundsID"></param>
        public static void RemoveClickBounds(Guid boundsID)
        {
            foreach (ClickBounds item in Bounds)
            {
                if (item.ID == boundsID)
                {
                    Bounds.Remove(item);
                    break;
                }
            }
        }
    }
}
