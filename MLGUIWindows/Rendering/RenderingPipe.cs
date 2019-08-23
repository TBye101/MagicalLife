using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MLAPI.Visual.Rendering;
using MLAPI.World.Data;
using MLGUIWindows.GUI.MainMenu;
using MLGUIWindows.Rendering.Map;
using MonoGUI.MonoGUI.Input;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.Rendering
{
    /// <summary>
    /// Handles drawing the entire screen.
    /// </summary>
    public static class RenderingPipe
    {
        /// <summary>
        /// Draws the screen.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawScreen(SpriteBatch spBatch)
        {
            if (World.DefaultWorldProvider.GetNumberOfDimensions() > 0)
            {
                MapRenderer.DrawMap(spBatch, RenderInfo.DimensionId);
            }
        }

        public static void DrawMouseLocation(SpriteBatch spBatch)
        {
            int x = Mouse.GetState().X;
            int y = Mouse.GetState().Y;
            string mouseLocation = "{ " + x + ", " + y + " }";
            SimpleTextRenderer.DrawString(MainMenuLayout.MainMenuFont, mouseLocation, new Rectangle(500, 500, 200, 50), SimpleTextRenderer.Alignment.Center, Color.AliceBlue, spBatch, RenderLayer.Gui);
        }

        /// <summary>
        /// Draws the GUI onto the screen.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawGui(SpriteBatch spBatch)
        {
            DrawContainers(spBatch);
        }

        private static void DrawContainers(SpriteBatch spBatch)
        {
            foreach (GuiContainer item in Enumerable.Reverse(BoundHandler.GuiWindows))
            {
                if (item.Visible)
                {
                    RenderYoungestChild(item, spBatch);
                }
            }
        }

        private static void RenderYoungestChild(GuiContainer item, SpriteBatch spBatch)
        {
            if (item.Child == null)
            {
                spBatch.Draw(item.Image, item.DrawingBounds, Color.White);

                foreach (GuiElement control in item.Controls)
                {
                    if (control.Visible)
                    {
                        control.Render(spBatch, item.DrawingBounds);
                    }
                }
            }
            else
            {
                RenderYoungestChild(item.Child, spBatch);
            }
        }
    }
}