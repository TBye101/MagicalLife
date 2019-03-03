using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        private int TextureID { get; set; }

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
        public MonoInputBox(string image, string CarrotTexture, Rectangle drawingBounds, int priority, string font, bool isLocked, Alignment textAlignment, bool isContained)
            : base(drawingBounds, priority, isContained, font)
        {
            KeyboardHandler.KeysPressed += this.KeyboardHandler_KeysPressed;
            this.CarrotPosition = this.Text.Count();
            this.CarrotTexture = AssetManager.Textures[AssetManager.GetTextureIndex(CarrotTexture)];
            this.TextureID = AssetManager.GetTextureIndex(image);
            this.IsLocked = isLocked;
            this.LoadCarrotInformation(font);
            this.TextAlignment = textAlignment;
        }

        private void KeyboardHandler_KeysPressed(object sender, Keys e)
        {
            if (!this.IsLocked && this.HasFocus)
            {
                switch (e)
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
                        this.AcceptKeystroke(KeyboardHandler.ToChar(e));
                        break;
                }
            }
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

        private void AcceptKeystroke(char? e)
        {
            if (!this.IsLocked && !this.LastKeySpecial && e != null)
            {
                string p1 = this.Text.Substring(0, this.CarrotPosition);
                p1 += e.ToString();

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

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            Rectangle location;
            int x = this.DrawingBounds.X + containerBounds.X;
            int y = this.DrawingBounds.Y + containerBounds.Y;
            location = new Rectangle(x, y, this.DrawingBounds.Width, this.DrawingBounds.Height);
            spBatch.Draw(AssetManager.Textures[this.TextureID], location, Color.White);
            DrawString(this.Font, this.Text, location, Alignment.Left, Color.White, spBatch, RenderLayer.GUI);

            Rectangle carrotLocation = this.CalculateCarrotBounds(this, containerBounds);

            spBatch.Draw(this.CarrotTexture, carrotLocation, Color.White);
        }

        private Rectangle CalculateCarrotBounds(MonoInputBox textbox, Rectangle containerBounds)
        {
            Vector2 size = textbox.Font.MeasureString(textbox.Text);
            Vector2 origin = size * 0.5f;

#pragma warning disable RCS1096 // Use bitwise operation instead of calling 'HasFlag'.
            if (textbox.TextAlignment.HasFlag(Alignment.Left))
            {
                origin.X += (textbox.DrawingBounds.Width / 2) - (size.X / 2);
            }

            if (textbox.TextAlignment.HasFlag(Alignment.Right))
            {
                origin.X -= (textbox.DrawingBounds.Width / 2) - (size.X / 2);
            }

            if (textbox.TextAlignment.HasFlag(Alignment.Top))
            {
                origin.Y += (textbox.DrawingBounds.Height / 2) - (size.Y / 2);
            }

            if (textbox.TextAlignment.HasFlag(Alignment.Bottom))
            {
                origin.Y -= (textbox.DrawingBounds.Height / 2) - (size.Y / 2);
            }

            string TextBeforeCarrot = textbox.Text.Substring(0, textbox.CarrotPosition);
            int XPos = (int)Math.Round(origin.X + textbox.DrawingBounds.X + textbox.Font.MeasureString(TextBeforeCarrot).X) + containerBounds.X;
            int YPos = (int)Math.Round(origin.Y + textbox.DrawingBounds.Y) + containerBounds.Y;

            if (textbox.TextAlignment == Alignment.Left)
            {
                XPos -= (int)Math.Round(origin.X);
                YPos += (int)Math.Round(origin.Y);
            }

            return new Rectangle(XPos, YPos, textbox.CarrotWidth, textbox.CarrotHeight);
        }
    }
}