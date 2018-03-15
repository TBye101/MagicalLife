using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using static MagicalLifeGUIWindows.Rendering.Text.SimpleTextRenderer;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// A generic label class.
    /// </summary>
    public class Label : GUIElement
    {
        /// <summary>
        /// The text contained in this label box.
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// The text alignment of this <see cref="Label"/>.
        /// </summary>
        public Alignment TextAlignment { get; private set; }

        public Label(Rectangle bounds, string font) : base("", bounds, int.MinValue, font)
        {
        }

        public Label() : base()
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
