using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Handles keyboard input.
    /// </summary>
    public static class KeyboardHandler
    {
        /// <summary>
        /// Used to compare what key changes have happened to the keyboard.
        /// </summary>
        private static KeyboardState Old;

        private static KeyboardModifiers Modifiers;

        /// <summary>
        /// This is called whenever keys are pressed down when they haven't been previously down.
        /// </summary>
        public static event EventHandler<Keys> KeysPressed;

        /// <summary>
        /// This is called when keys are being held down.
        /// </summary>
        public static event EventHandler<Keys> KeysDown;

        /// <summary>
        /// This is called whenever keys are released.
        /// </summary>
        public static event EventHandler<Keys> KeysReleased;

        public static void Initialize()
        {
        }

        /// <summary>
        /// Handles keyboard input.
        /// </summary>
        /// <param name="clickData"></param>
        /// <param name="time"></param>
        public static void UpdateKeyboardInput(GameTime time)
        {
            GetChanges(out List<Keys> pressed, out List<Keys> down, out List<Keys> released);

            if (pressed.Count > 0)
            {
                int length = pressed.Count;
                for (int i = 0; i < length; i++)
                {
                    KeysPressed?.Invoke(null, pressed[i]);
                }
            }

            if (down.Count > 0)
            {
                int length = down.Count;
                for (int i = 0; i < length; i++)
                {
                    KeysDown?.Invoke(null, down[i]);
                }
            }

            if (released.Count > 0)
            {
                int length = released.Count;
                for (int i = 0; i < length; i++)
                {
                    KeysReleased?.Invoke(null, released[i]);
                }
            }

            KeyboardState keyboardState = Keyboard.GetState();

            Modifiers = KeyboardModifiers.None;

            if (keyboardState.IsKeyDown(Keys.LeftControl) || keyboardState.IsKeyDown(Keys.RightControl))
            {
                Modifiers |= KeyboardModifiers.Control;
            }

            if (keyboardState.IsKeyDown(Keys.LeftShift) || keyboardState.IsKeyDown(Keys.RightShift))
            {
                Modifiers |= KeyboardModifiers.Shift;
            }

            if (keyboardState.IsKeyDown(Keys.LeftAlt) || keyboardState.IsKeyDown(Keys.RightAlt))
            {
                Modifiers |= KeyboardModifiers.Alt;
            }
        }

        /// <summary>
        /// Calculate the changes made to the keyboard since the last calculation.
        /// </summary>
        /// <param name="Pressed">The keys newly pressed down.</param>
        /// <param name="Down">The keys that were already down.</param>
        /// <param name="Released">The keys newly released.</param>
        private static void GetChanges(out List<Keys> Pressed, out List<Keys> Down, out List<Keys> Released)
        {
            KeyboardState key = Keyboard.GetState();

            Keys[] OldDown = Old.GetPressedKeys();
            Keys[] NewDown = key.GetPressedKeys();

            //Figures out which keys are newly pressed
            Pressed = NewDown.Where(x => !OldDown.Contains(x)).ToList();

            //Figure out which keys are still staying down
            Down = NewDown.Where(x => OldDown.Contains(x)).ToList();

            //Figure out which keys were released
            Released = OldDown.Where(x => !NewDown.Contains(x)).ToList();

            //This function is done with the new keyboard state, so the new becomes the old.
            Old = key;
        }

        //Borrowed shamelessly from Monogame.extended
        public static char? ToChar(Keys key)

        {
            bool isShiftDown = (Modifiers & KeyboardModifiers.Shift) == KeyboardModifiers.Shift;

            if (key == Keys.A)
            {
                return isShiftDown ? 'A' : 'a';
            }

            if (key == Keys.B)
            {
                return isShiftDown ? 'B' : 'b';
            }

            if (key == Keys.C)
            {
                return isShiftDown ? 'C' : 'c';
            }

            if (key == Keys.D)
            {
                return isShiftDown ? 'D' : 'd';
            }

            if (key == Keys.E)
            {
                return isShiftDown ? 'E' : 'e';
            }

            if (key == Keys.F)
            {
                return isShiftDown ? 'F' : 'f';
            }

            if (key == Keys.G)
            {
                return isShiftDown ? 'G' : 'g';
            }

            if (key == Keys.H)
            {
                return isShiftDown ? 'H' : 'h';
            }

            if (key == Keys.I)
            {
                return isShiftDown ? 'I' : 'i';
            }

            if (key == Keys.J)
            {
                return isShiftDown ? 'J' : 'j';
            }

            if (key == Keys.K)
            {
                return isShiftDown ? 'K' : 'k';
            }

            if (key == Keys.L)
            {
                return isShiftDown ? 'L' : 'l';
            }

            if (key == Keys.M)
            {
                return isShiftDown ? 'M' : 'm';
            }

            if (key == Keys.N)
            {
                return isShiftDown ? 'N' : 'n';
            }

            if (key == Keys.O)
            {
                return isShiftDown ? 'O' : 'o';
            }

            if (key == Keys.P)
            {
                return isShiftDown ? 'P' : 'p';
            }

            if (key == Keys.Q)
            {
                return isShiftDown ? 'Q' : 'q';
            }

            if (key == Keys.R)
            {
                return isShiftDown ? 'R' : 'r';
            }

            if (key == Keys.S)
            {
                return isShiftDown ? 'S' : 's';
            }

            if (key == Keys.T)
            {
                return isShiftDown ? 'T' : 't';
            }

            if (key == Keys.U)
            {
                return isShiftDown ? 'U' : 'u';
            }

            if (key == Keys.V)
            {
                return isShiftDown ? 'V' : 'v';
            }

            if (key == Keys.W)
            {
                return isShiftDown ? 'W' : 'w';
            }

            if (key == Keys.X)
            {
                return isShiftDown ? 'X' : 'x';
            }

            if (key == Keys.Y)
            {
                return isShiftDown ? 'Y' : 'y';
            }

            if (key == Keys.Z)
            {
                return isShiftDown ? 'Z' : 'z';
            }

            if (((key == Keys.D0) && !isShiftDown) || (key == Keys.NumPad0))
            {
                return '0';
            }

            if (((key == Keys.D1) && !isShiftDown) || (key == Keys.NumPad1))
            {
                return '1';
            }

            if (((key == Keys.D2) && !isShiftDown) || (key == Keys.NumPad2))
            {
                return '2';
            }

            if (((key == Keys.D3) && !isShiftDown) || (key == Keys.NumPad3))
            {
                return '3';
            }

            if (((key == Keys.D4) && !isShiftDown) || (key == Keys.NumPad4))
            {
                return '4';
            }

            if (((key == Keys.D5) && !isShiftDown) || (key == Keys.NumPad5))
            {
                return '5';
            }

            if (((key == Keys.D6) && !isShiftDown) || (key == Keys.NumPad6))
            {
                return '6';
            }

            if (((key == Keys.D7) && !isShiftDown) || (key == Keys.NumPad7))
            {
                return '7';
            }

            if (((key == Keys.D8) && !isShiftDown) || (key == Keys.NumPad8))
            {
                return '8';
            }

            if (((key == Keys.D9) && !isShiftDown) || (key == Keys.NumPad9))
            {
                return '9';
            }

            if ((key == Keys.D0) && isShiftDown)
            {
                return ')';
            }

            if ((key == Keys.D1) && isShiftDown)
            {
                return '!';
            }

            if ((key == Keys.D2) && isShiftDown)
            {
                return '@';
            }

            if ((key == Keys.D3) && isShiftDown)
            {
                return '#';
            }

            if ((key == Keys.D4) && isShiftDown)
            {
                return '$';
            }

            if ((key == Keys.D5) && isShiftDown)
            {
                return '%';
            }

            if ((key == Keys.D6) && isShiftDown)
            {
                return '^';
            }

            if ((key == Keys.D7) && isShiftDown)
            {
                return '&';
            }

            if ((key == Keys.D8) && isShiftDown)
            {
                return '*';
            }

            if ((key == Keys.D9) && isShiftDown)
            {
                return '(';
            }

            if (key == Keys.Space)
            {
                return ' ';
            }

            if (key == Keys.Tab)
            {
                return '\t';
            }

            if (key == Keys.Enter)
            {
                return (char)13;
            }

            if (key == Keys.Back)
            {
                return (char)8;
            }

            if (key == Keys.Add)
            {
                return '+';
            }

            if (key == Keys.Decimal)
            {
                return '.';
            }

            if (key == Keys.Divide)
            {
                return '/';
            }

            if (key == Keys.Multiply)
            {
                return '*';
            }

            if (key == Keys.OemBackslash)
            {
                return '\\';
            }

            if ((key == Keys.OemComma) && !isShiftDown)
            {
                return ',';
            }

            if ((key == Keys.OemComma) && isShiftDown)
            {
                return '<';
            }

            if ((key == Keys.OemOpenBrackets) && !isShiftDown)
            {
                return '[';
            }

            if ((key == Keys.OemOpenBrackets) && isShiftDown)
            {
                return '{';
            }

            if ((key == Keys.OemCloseBrackets) && !isShiftDown)
            {
                return ']';
            }

            if ((key == Keys.OemCloseBrackets) && isShiftDown)
            {
                return '}';
            }

            if ((key == Keys.OemPeriod) && !isShiftDown)
            {
                return '.';
            }

            if ((key == Keys.OemPeriod) && isShiftDown)
            {
                return '>';
            }

            if ((key == Keys.OemPipe) && !isShiftDown)
            {
                return '\\';
            }

            if ((key == Keys.OemPipe) && isShiftDown)
            {
                return '|';
            }

            if ((key == Keys.OemPlus) && !isShiftDown)
            {
                return '=';
            }

            if ((key == Keys.OemPlus) && isShiftDown)
            {
                return '+';
            }

            if ((key == Keys.OemMinus) && !isShiftDown)
            {
                return '-';
            }

            if ((key == Keys.OemMinus) && isShiftDown)
            {
                return '_';
            }

            if ((key == Keys.OemQuestion) && !isShiftDown)
            {
                return '/';
            }

            if ((key == Keys.OemQuestion) && isShiftDown)
            {
                return '?';
            }

            if ((key == Keys.OemQuotes) && !isShiftDown)
            {
                return '\'';
            }

            if ((key == Keys.OemQuotes) && isShiftDown)
            {
                return '"';
            }

            if ((key == Keys.OemSemicolon) && !isShiftDown)
            {
                return ';';
            }

            if ((key == Keys.OemSemicolon) && isShiftDown)
            {
                return ':';
            }

            if ((key == Keys.OemTilde) && !isShiftDown)
            {
                return '`';
            }

            if ((key == Keys.OemTilde) && isShiftDown)
            {
                return '~';
            }

            if (key == Keys.Subtract)
            {
                return '-';
            }

            return null;
        }
    }
}