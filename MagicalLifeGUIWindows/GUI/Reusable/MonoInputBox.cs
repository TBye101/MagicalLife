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
        private readonly bool LastKeySpecial = false;

        /// <summary>
        /// If this is true, this <see cref="MonoInputBox"/> doesn't allow editing.
        /// </summary>
        public bool IsLocked { get; }

        /// <summary>
        /// The text alignment of this <see cref="MonoInputBox"/>.
        /// </summary>
        public Alignment TextAlignment { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="image"></param>
        /// <param name="CarrotTexture"></param>
        /// <param name="drawingBounds"></param>
        /// <param name="priority"></param>
        /// <param name="font"></param>
        /// <param name="isLocked"></param>
        /// <param name="textAlignment"></param>
        /// <param name="isContained">If true, this GUI element is within a container.</param>
        public MonoInputBox(string image, string CarrotTexture, Rectangle drawingBounds, int priority, string font, bool isLocked, Alignment textAlignment, bool isContained) : base(image, drawingBounds, priority, isContained, font)
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
                    case Microsoft.Xna.Framework.Input.Keys.Back:
                        this.Back();
                        break;

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