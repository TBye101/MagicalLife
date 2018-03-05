using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    public class InputBox : GUIElement
    {
        /// <summary>
        /// The text contained in this input box.
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// The position of the carrot.
        /// </summary>
        public int CarrotPosition { get; private set; } = 0;

        public static int CarrotSize { get; private set; } = 2;

        /// <summary>
        /// The texture of the blinking carrot.
        /// </summary>
        public Texture2D CarrotTexture { get; private set; }

        /// <summary>
        /// If this is true, this <see cref="InputBox"/> doesn't allow editing.
        /// </summary>
        public bool IsLocked { get; }

        public InputBox(Texture2D image, Texture2D CarrotTexture, Rectangle drawingBounds, int priority, string font, bool isLocked) : base(image, drawingBounds, priority, font)
        {
            KeyboardHandler.keyboardListener.KeyPressed += this.KeyboardListener_KeyPressed;
            KeyboardHandler.keyboardListener.KeyTyped += this.KeyboardListener_KeyTyped;
            this.CarrotPosition = this.Text.Count();
            this.CarrotTexture = CarrotTexture;
            this.IsLocked = isLocked;
        }

        private void KeyboardListener_KeyTyped(object sender, KeyboardEventArgs e)
        {
            if (!this.IsLocked)
            {
                this.Text.Insert(this.CarrotPosition, e.Character.ToString());
                this.CarrotPosition += 1;
            }
        }

        private void KeyboardListener_KeyPressed(object sender, KeyboardEventArgs e)
        {
            if (!this.IsLocked)
            {
                switch (e.Key)
                {
                    case Microsoft.Xna.Framework.Input.Keys.Enter:
                        this.Text += "\n";
                        this.CarrotPosition += 1;
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Left:
                        if (this.CarrotPosition > 0)
                        {
                            this.CarrotPosition -= 1;
                        }
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Right:
                        if (this.Text.Count() != this.CarrotPosition)
                        {
                            this.CarrotPosition += 1;
                        }
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Delete:
                        string p1 = this.Text.Substring(0, this.CarrotPosition);
                        string p2 = this.Text.Substring(this.CarrotPosition + 1, this.Text.Count());
                        this.Text = p1 + p2;
                        break;
                    case Microsoft.Xna.Framework.Input.Keys.Back:
                        string p3 = this.Text.Substring(0, this.CarrotPosition - 1);
                        string p4 = this.Text.Substring(this.CarrotPosition, this.Text.Count());
                        break;
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
