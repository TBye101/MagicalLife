using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Crafting
{
    /// <summary>
    /// Implementers of this belong on the action bar.
    /// </summary>
    public interface IActionBarItem
    {
        /// <summary>
        /// The ID of the texture to display for this action bar item.
        /// Must be 32x32 pixels.
        /// </summary>
        /// <returns></returns>
        int GetDisplayTextureID();

        /// <summary>
        /// The name of this action bar item.
        /// </summary>
        /// <returns></returns>
        string GetDisplayName();

        /// <summary>
        /// A collection of keywords to allow the user to filter by.
        /// </summary>
        /// <returns></returns>
        string[] GetKeywords();

        /// <summary>
        /// Should return the display name of the mod this action bar item is from.
        /// </summary>
        /// <returns></returns>
        string GetModName();

        /// <summary>
        /// Called when this action bar item is clicked on within the action bar.
        /// </summary>
        void Clicked();

        /// <summary>
        /// Called when this action bar item is special clicked on.
        /// </summary>
        void SpecialClicked();
    }
}
