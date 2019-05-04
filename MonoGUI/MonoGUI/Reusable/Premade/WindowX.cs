using MagicalLifeAPI.Asset;
using MagicalLifeAPI.DataTypes;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.Reusable.Premade
{
    /// <summary>
    /// The x in the corner of the window to close the window.
    /// </summary>
    public class WindowX : MonoButton
    {
        private const int TextureWidth = 32;
        private const int TextureHeight = 32;

        /// <summary>
        ///
        /// </summary>
        /// <param name="containingSize">The size of the containing form.</param>
        public WindowX(Point2D containingSize) :
            base(TextureLoader.GUIX,
                new Rectangle(containingSize.X - TextureWidth, 0, TextureWidth, TextureHeight), true, "")
        {
        }
    }
}