using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static MagicalLifeGUIWindows.Rendering.Text.SimpleTextRenderer;

namespace MagicalLifeGUIWindows.Rendering.GUI
{
    /// <summary>
    /// Knows how to render various GUI components.
    /// </summary>
    public static class GUIRenderer
    {
        public static void DrawLabelInContainer(MonoLabel label, ref SpriteBatch spBatch, GUIContainer container)
        {
            int x = container.DrawingBounds.X + label.DrawingBounds.X;
            int y = container.DrawingBounds.Y + label.DrawingBounds.Y;
            int width = label.DrawingBounds.Width;
            int height = label.DrawingBounds.Height;

            Rectangle Bounds = new Rectangle(x, y, width, height);
            SimpleTextRenderer.DrawString(label.Font, label.Text, Bounds, label.TextAlignment, RenderingPipe.colorMask, ref spBatch);
        }

        public static void DrawInputBoxInContainer(MonoInputBox textbox, ref SpriteBatch spBatch, GUIContainer container)
        {
            Rectangle location;
            int x = textbox.DrawingBounds.X + container.DrawingBounds.X;
            int y = textbox.DrawingBounds.Y + container.DrawingBounds.Y;
            location = new Rectangle(x, y, textbox.DrawingBounds.Width, textbox.DrawingBounds.Height);
            spBatch.Draw(textbox.Image, location, RenderingPipe.colorMask);
            DrawString(textbox.Font, textbox.Text, location, Alignment.Left, RenderingPipe.colorMask, ref spBatch);

            Rectangle carrotLocation = CalculateCarrotBounds(textbox, container);

            spBatch.Draw(textbox.CarrotTexture, carrotLocation, RenderingPipe.colorMask);
        }

        private static Rectangle CalculateCarrotBounds(MonoInputBox textbox, GUIContainer container)
        {
            Vector2 size = textbox.Font.MeasureString(textbox.Text);
            Vector2 pos = new Vector2(textbox.DrawingBounds.Center.X, textbox.DrawingBounds.Center.Y);
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
            int XPos = (int)Math.Round(origin.X + textbox.DrawingBounds.X + textbox.Font.MeasureString(TextBeforeCarrot).X) + container.DrawingBounds.X;
            int YPos = (int)Math.Round(origin.Y + textbox.DrawingBounds.Y) + container.DrawingBounds.Y;

            switch (textbox.TextAlignment)
            {
                case Alignment.Left:
                    XPos -= (int)Math.Round(origin.X);
                    YPos += (int)Math.Round(origin.Y);
                    break;
            }

            return new Rectangle(XPos, YPos, textbox.CarrotWidth, textbox.CarrotHeight);
        }

        public static void DrawButtonInContainer(MonoButton button, ref SpriteBatch spBatch, GUIContainer container)
        {
            Rectangle location;
            int x = button.DrawingBounds.X + container.DrawingBounds.X;
            int y = button.DrawingBounds.Y + container.DrawingBounds.Y;
            location = new Rectangle(x, y, button.DrawingBounds.Width, button.DrawingBounds.Height);
            spBatch.Draw(button.Image, location, RenderingPipe.colorMask);
            SimpleTextRenderer.DrawString(button.Font, button.Text, location, Alignment.Center, RenderingPipe.colorMask, ref spBatch);
        }
    }
}