using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.GUI
{
    /// <summary>
    /// All objects in the game that can be clicked on inherit from this.
    /// </summary>
    public interface ISelectable
    {
        /// <summary>
        /// This returns a <see cref="SelectionType"/> so we can differentiate between the catagories of various in game objects.
        /// Ex: An item such as wood would be considered the same as another type of item, but creatures are not the same as wood.
        /// </summary>
        /// <param name="selectable"></param>
        /// <returns></returns>
        SelectionType InGameObjectType(ISelectable selectable);
    }
}
