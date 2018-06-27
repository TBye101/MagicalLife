using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using static MagicalLifeGUIWindows.Rendering.Text.SimpleTextRenderer;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// A generic label class.
    /// </summary>
    public class MonoLabel : GUIElement
    {
        /// <summary>
        /// The text contained in this label box.
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// The text alignment of this <see cref="MonoLabel"/>.
        /// </summary>
        public Alignment TextAlignment { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bounds"></param>
        /// <param name="image"></param>
        /// <param name="font"></param>
        /// <param name="isContained">If true, this GUI element is within a container.</param>
        public MonoLabel(Rectangle bounds, string image, bool isContained, string font = "MainMenuFont12x") : base(image, bounds, int.MinValue, isContained, font)
        {
        }

        public MonoLabel() : base()
        {
        }

        public override void Click(MouseEventArgs e)
        {
        }

        public override void DoubleClick(MouseEventArgs e)
        {
        }
    }
}