using MagicalLifeGUIWindows.GUI.MainMenu;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicalLifeGUIWindows.Rendering.Text.SimpleTextRenderer;

namespace MagicalLifeGUIWindows.Rendering.GUI
{
    /// <summary>
    /// Knows how to render various GUI components.
    /// </summary>
    public static class GUIRenderer
    {
        public static void DrawInputBox(InputBox textbox, ref SpriteBatch spBatch)
        {
            spBatch.Draw(textbox.Image, textbox.DrawingBounds, RenderingPipe.colorMask);
            DrawString(textbox.Font, textbox.Text, textbox.DrawingBounds, Alignment.Right, RenderingPipe.colorMask, ref spBatch);

            Rectangle carrotLocation = textbox.DrawingBounds;
            carrotLocation.X += (InputBox.CarrotSize * textbox.CarrotPosition);

            spBatch.Draw(textbox.CarrotTexture, carrotLocation, RenderingPipe.colorMask);
        }

        public static void DrawInputBoxInContainer(InputBox textbox, ref SpriteBatch spBatch, GUIContainer container)
        {
            Rectangle location;
            int x = textbox.DrawingBounds.X + container.DrawingBounds.X;
            int y = textbox.DrawingBounds.Y + container.DrawingBounds.Y;
            location = new Rectangle(x, y, textbox.DrawingBounds.Width, textbox.DrawingBounds.Height);
            spBatch.Draw(textbox.Image, location, RenderingPipe.colorMask);
            DrawString(textbox.Font, textbox.Text, location, Alignment.Left, RenderingPipe.colorMask, ref spBatch);

            Rectangle carrotLocation = location;
            carrotLocation.X += (InputBox.CarrotSize * textbox.CarrotPosition);
            carrotLocation.Width = 2;
            carrotLocation.Height = 4;
            carrotLocation.Y = location.Y + 2;

            spBatch.Draw(textbox.CarrotTexture, carrotLocation, RenderingPipe.colorMask);
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

        public static void DrawButton(MonoButton button, ref SpriteBatch spBatch)
        {
            if (button.Visible)
            {
                spBatch.Draw(button.Image, button.DrawingBounds, RenderingPipe.colorMask);
                SimpleTextRenderer.DrawString(MainMenuLayout.MainMenuFont, button.Text, button.DrawingBounds, Alignment.Center, RenderingPipe.colorMask, ref spBatch);
            }
        }
    }
}
