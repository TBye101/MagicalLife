using MagicalLifeAPI.World.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Crafting
{
    /// <summary>
    /// All recipes implement this.
    /// </summary>
    public interface IRecipe
    {
        /// <summary>
        /// Returns the an example of the item that this recipe creates.
        /// </summary>
        /// <returns></returns>
        Item GetExampleOutput();

        /// <summary>
        /// Return a constant but unique ID for this recipe.
        /// Must be consistent between games/loads. 
        /// </summary>
        /// <returns></returns>
        Guid GetUniqueID();
    }
}
