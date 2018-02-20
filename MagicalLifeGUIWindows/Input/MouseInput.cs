using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Used to describe the changes between <see cref="MouseState"/> objects.
    /// </summary>
    public class MouseInput
    {
        //
        // Summary:
        //     Gets the change in the x axis since the last mouse input.
        public int XChange { get; }
        //
        // Summary:
        //     Gets the change in the y axis since the last mouse input.
        public int YChange { get; }

        //
        // Summary:
        //     Gets cursor position.
        public Point Position { get; }
        //
        // Summary:
        //     Gets state of the left mouse button.
        public ButtonState LeftButton { get; }
        //
        // Summary:
        //     Gets state of the middle mouse button.
        public ButtonState MiddleButton { get; }
        //
        // Summary:
        //     Gets state of the right mouse button.
        public ButtonState RightButton { get; }
        //
        // Summary:
        //     Returns cumulative scroll wheel value since the game start.
        public int ScrollWheelValue { get; }
    }
}
