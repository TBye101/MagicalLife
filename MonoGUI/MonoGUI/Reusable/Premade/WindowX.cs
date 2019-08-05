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
        private const int TEXTURE_WIDTH = 32;
        private const int TEXTURE_HEIGHT = 32;

        /// <summary>
        ///
        /// </summary>
        /// <param name="containingSize">The size of the containing form.</param>
        public WindowX(Point2D containingSize) :
            base(TextureLoader.Guix,
                new Rectangle(containingSize.X - TEXTURE_WIDTH, 0, TEXTURE_WIDTH, TEXTURE_HEIGHT), true, "")
        {
        }
    }
}