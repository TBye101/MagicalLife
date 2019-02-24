using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.GUI.MainMenu;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input;
using MagicalLifeGUIWindows.Rendering.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using static MagicalLifeGUIWindows.Rendering.Text.SimpleTextRenderer;

namespace MagicalLifeGUIWindows.Rendering
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
            if (World.Dimensions.Count > 0)
            {
                MapRenderer.DrawMap(spBatch, RenderInfo.Dimension);
            }
        }

        public static void DrawMouseLocation(SpriteBatch spBatch)
        {
            int x = Mouse.GetState().X;
            int y = Mouse.GetState().Y;
            string mouseLocation = "{ " + x + ", " + y + " }";
            DrawString(MainMenuLayout.MainMenuFont, mouseLocation, new Rectangle(500, 500, 200, 50), Alignment.Center, Color.AliceBlue, spBatch, RenderLayer.GUI);
        }

        /// <summary>
        /// Draws the GUI onto the screen.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawGUI(SpriteBatch spBatch)
        {
            DrawContainers(spBatch);
        }

        private static void DrawContainers(SpriteBatch spBatch)
        {
            foreach (GUIContainer item in Enumerable.Reverse(BoundHandler.GUIWindows))
            {
                if (item.Visible)
                {
                    RenderYoungestChild(item, spBatch);
                }
            }
        }

        private static void RenderYoungestChild(GUIContainer item, SpriteBatch spBatch)
        {
            if (item.Child == null)
            {
                spBatch.Draw(item.Image, item.DrawingBounds, Color.White);

                foreach (GUIElement control in item.Controls)
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