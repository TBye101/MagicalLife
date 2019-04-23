using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Reusable.API
{
    public interface IUIContainer
    {

        /// <summary>
        /// Refreshes the elements on the screen
        /// </summary>
        void Paint();

        /// <summary>
        /// Gets the children of this container.
        /// </summary>
        /// <returns>A collection of GUI Elements this container has or null</returns>
        ICollection<GUIElement> GetChildren();

        /// <summary>
        /// Adds the specified element to the container and refreshes the layout.
        /// </summary>
        /// <param name="element">The element to add.</param>
        void Add(GUIElement element); 

    }
}
