using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Handles keyboard input.
    /// </summary>
    public static class KeyboardHandler
    {
        public static KeyboardListener keyboardListener;

        private static EscapeHandler escapeHandler;

        public static void Initialize()
        {
            keyboardListener = new KeyboardListener();
            keyboardListener.KeyPressed += KeyboardListener_KeyPressed;

            escapeHandler = new EscapeHandler(keyboardListener);
        }

        private static void KeyboardListener_KeyPressed(object sender, KeyboardEventArgs e)
        {
            Point loc = Mouse.GetState().Position;

            switch (e.Key)
            {
                case Microsoft.Xna.Framework.Input.Keys.None:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Back:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Tab:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Enter:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.CapsLock:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Escape:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Space:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.PageUp:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.PageDown:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.End:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Home:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Left:
                    Mouse.SetPosition(loc.X - 1, loc.Y);
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Up:
                    Mouse.SetPosition(loc.X, loc.Y - 1);
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Right:
                    Mouse.SetPosition(loc.X + 1, loc.Y);
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Down:
                    Mouse.SetPosition(loc.X, loc.Y + 1);
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Select:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Print:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Execute:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.PrintScreen:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Insert:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Delete:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Help:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.D0:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.D1:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.D2:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.D3:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.D4:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.D5:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.D6:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.D7:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.D8:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.D9:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.A:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.B:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.C:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.D:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.E:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.G:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.H:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.I:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.J:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.K:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.L:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.M:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.N:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.O:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.P:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Q:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.R:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.S:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.T:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.U:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.V:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.W:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.X:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Y:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Z:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.LeftWindows:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.RightWindows:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Apps:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Sleep:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.NumPad0:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.NumPad1:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.NumPad2:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.NumPad3:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.NumPad4:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.NumPad5:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.NumPad6:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.NumPad7:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.NumPad8:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.NumPad9:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Multiply:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Add:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Separator:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Subtract:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Decimal:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Divide:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F1:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F2:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F3:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F4:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F5:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F6:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F7:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F8:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F9:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F10:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F11:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F12:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F13:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F14:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F15:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F16:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F17:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F18:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F19:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F20:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F21:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F22:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F23:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.F24:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.NumLock:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Scroll:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.LeftShift:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.RightShift:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.LeftControl:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.RightControl:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.LeftAlt:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.RightAlt:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.BrowserBack:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.BrowserForward:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.BrowserRefresh:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.BrowserStop:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.BrowserSearch:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.BrowserFavorites:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.BrowserHome:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.VolumeMute:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.VolumeDown:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.VolumeUp:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.MediaNextTrack:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.MediaPreviousTrack:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.MediaStop:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.MediaPlayPause:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.LaunchMail:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.SelectMedia:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.LaunchApplication1:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.LaunchApplication2:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemSemicolon:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemPlus:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemComma:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemMinus:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemPeriod:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemQuestion:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemTilde:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemOpenBrackets:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemPipe:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemCloseBrackets:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemQuotes:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Oem8:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemBackslash:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.ProcessKey:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Attn:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Crsel:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Exsel:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.EraseEof:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Play:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Zoom:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Pa1:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemClear:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.ChatPadGreen:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.ChatPadOrange:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Pause:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.ImeConvert:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.ImeNoConvert:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Kana:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.Kanji:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemAuto:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemCopy:
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemEnlW:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles keyboard input.
        /// </summary>
        /// <param name="clickData"></param>
        /// <param name="time"></param>
        public static void UpdateKeyboardInput(GameTime time)
        {
            keyboardListener.Update(time);
        }
    }
}
