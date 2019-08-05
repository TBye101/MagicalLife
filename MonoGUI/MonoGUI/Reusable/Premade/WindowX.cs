using MLAPI.Asset;
using MLAPI.DataTypes;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MonoGUI.MonoGUI.Reusable.Premade
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