using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.Asset;
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
        /// If true, then the last key was already handled as a special key.
        /// </summary>
        private bool LastKeySpecial = false;

        /// <summary>
        /// If this is true, this <see cref="InputBox"/> doesn't allow editing.
        /// </summary>
        public bool IsLocked { get; }

        public InputBox(string image, string CarrotTexture, Rectangle drawingBounds, int priority, string font, bool isLocked) : base(image, drawingBounds, priority, font)
        {
            KeyboardHandler.keyboardListener.KeyPressed += this.KeyboardListener_KeyPressed;
            this.CarrotPosition = this.Text.Count();
            this.CarrotTexture = AssetManager.Textures[AssetManager.GetTextureIndex(CarrotTexture)];
            this.Image = AssetManager.Textures[AssetManager.GetTextureIndex(image)];
            this.IsLocked = isLocked;
        }

        public InputBox() : base()
        {

        }

        private void KeyboardListener_KeyPressed(object sender, KeyboardEventArgs e)
        {
            if (!this.IsLocked)
            {
                switch (e.Key)
                {
                    case Microsoft.Xna.Framework.Input.Keys.Enter:
                        this.Enter();
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Left:
                        this.Left();
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Right:
                        this.Right();
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Delete:
                        this.Delete();
                        break;

                    case Microsoft.Xna.Framework.Input.Keys.Back:
                        this.Back();
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
            string p1 = this.Text.Substring(0, this.CarrotPosition);
            string p2 = this.Text.Substring(this.CarrotPosition + 1, this.Text.Count());
            this.Text = p1 + p2;
        }

        public override void Click(MouseEventArgs e)
        {
        }

        public override void DoubleClick(MouseEventArgs e)
        {
        }
    }
}
