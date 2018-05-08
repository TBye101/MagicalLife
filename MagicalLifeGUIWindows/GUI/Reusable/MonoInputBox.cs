using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Linq;
using static MagicalLifeGUIWindows.Rendering.Text.SimpleTextRenderer;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    public class MonoInputBox : GUIElement
    {
        /// <summary>
        /// The text contained in this input box.
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// The position of the carrot.
        /// </summary>
        public int CarrotPosition { get; private set; } = 0;

        /// <summary>
        /// The width of the blinking carrot.
        /// </summary>
        public int CarrotWidth { get; private set; } = 0;

        /// <summary>
        /// The height of the blinking carrot.
        /// </summary>
        public int CarrotHeight { get; private set; } = 0;

        /// <summary>
        /// The texture of the blinking carrot.
        /// </summary>
        public Texture2D CarrotTexture { get; private set; }

        /// <summary>
        /// If true, then the last key was already handled as a special key.
        /// </summary>
        private bool LastKeySpecial = false;

        /// <summary>
        /// If this is true, this <see cref="MonoInputBox"/> doesn't allow editing.
        /// </summary>
        public bool IsLocked { get; }

        /// <summary>
        /// The text alignment of this <see cref="MonoInputBox"/>.
        /// </summary>
        public Alignment TextAlignment { get; private set; }

        public MonoInputBox(string image, string CarrotTexture, Rectangle drawingBounds, int priority, string font, bool isLocked, Alignment textAlignment) : base(image, drawingBounds, priority, font)
        {
            KeyboardHandler.keyboardListener.KeyPressed += this.KeyboardListener_KeyPressed;
            this.CarrotPosition = this.Text.Count();
            this.CarrotTexture = AssetManager.Textures[AssetManager.GetTextureIndex(CarrotTexture)];
            this.Image = AssetManager.Textures[AssetManager.GetTextureIndex(image)];
            this.IsLocked = isLocked;
            this.LoadCarrotInformation(font);
            this.TextAlignment = textAlignment;
        }

        private void LoadCarrotInformation(string font)
        {
            this.Font = Game1.AssetManager.Load<SpriteFont>(font);
            Vector2 size = this.Font.MeasureString("|");
            this.CarrotWidth = (int)Math.Round(size.X);
            this.CarrotHeight = (int)Math.Round(size.Y);
        }

        public MonoInputBox() : base()
        {
        }

        private void KeyboardListener_KeyPressed(object sender, KeyboardEventArgs e)
        {
            if (!this.IsLocked && this.HasFocus)
            {
                switch (e.Key)
                {
                    case Microsoft.Xna.Framework.Input.Keys.None:
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Back:
                        this.Back();
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Tab:
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Enter:
                        this.Enter();
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.CapsLock:
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Escape:
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
                        this.Left();
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Up:
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Right:
                        this.Right();
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Down:
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
                        this.Delete();
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Help:
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.LeftWindows:
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.RightWindows:
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Apps:
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Sleep:
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Separator:
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
                        this.AcceptKeystroke(e);
                        break;
                }
            }
        }

        private void AcceptKeystroke(KeyboardEventArgs e)
        {
            if (!this.IsLocked && !this.LastKeySpecial)
            {
                string p1 = this.Text.Substring(0, this.CarrotPosition);
                p1 += e.Character.ToString();

                string p2 = this.Text.Substring(this.CarrotPosition, this.Text.Count() - this.CarrotPosition);
                this.Text = p1 + p2;
                this.CarrotPosition += 1;
            }
        }

        private void Enter()
        {
            this.Text += "\n";
            this.CarrotPosition += 1;
        }

        private void Right()
        {
            if (this.Text.Count() != this.CarrotPosition)
            {
                this.CarrotPosition += 1;
            }
        }

        private void Left()
        {
            if (this.CarrotPosition > 0)
            {
                this.CarrotPosition -= 1;
            }
        }

        private void Back()
        {
            if (this.CarrotPosition > 0)
            {
                string p3 = this.Text.Substring(0, this.CarrotPosition - 1);

                if (this.CarrotPosition != this.Text.Count())
                {
                    string p4 = this.Text.Substring(this.CarrotPosition, this.Text.Count() - this.CarrotPosition);
                    this.Text = p3 + p4;
                }
                else
                {
                    this.Text = p3;
                }

                if (this.CarrotPosition > 0)
                {
                    this.CarrotPosition -= 1;
                }
            }
        }

        private void Delete()
        {
            if (this.CarrotPosition != this.Text.Count())
            {
                string p1 = this.Text.Substring(0, this.CarrotPosition);

                if (this.Text.Count() != this.CarrotPosition + 1)
                {
                    string p2 = this.Text.Substring(startIndex: this.CarrotPosition + 1, length: this.Text.Count() - (this.CarrotPosition + 1));
                    this.Text = p1 + p2;
                }
                else
                {
                    this.Text = p1;
                }
            }
        }

        public override void Click(MouseEventArgs e)
        {
        }

        public override void DoubleClick(MouseEventArgs e)
        {
        }
    }
}