using MagicalLifeAPI.Asset;
using MagicalLifeAPI.DataTypes;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;

namespace MagicalLifeGUIWindows.GUI.Reusable.Premade
{
    /// <summary>
    /// The x in the corner of the window to close the window.
    /// </summary>
    public class WindowX : MonoButton
    {
        /// <summary>
        /// Raised when the containing window should be closed.
        /// </summary>
        public event EventHandler XClicked;

        private static readonly int TextureWidth = 32;
        private static readonly int TextureHeight = 32;

        /// <param name="containingSize">The size of the containing form.</param>
        public WindowX(Point2D containingSize) :
            base(TextureLoader.GUIX,
                new Rectangle(containingSize.X - TextureWidth, 0, TextureWidth, TextureHeight), true, "")
        {
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            this.XClicked?.Invoke(null, e);
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            this.XClicked?.Invoke(null, e);
        }
    }
}