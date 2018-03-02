using MagicalLifeAPI.Asset;
using MagicalLifeAPI.World;
using MagicalLifeGUIWindows.GUI.MainMenu;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MagicalLifeGUIWindows.Rendering
{
    /// <summary>
    /// Handles drawing the entire screen.
    /// </summary>
    public static class RenderingPipe
    {
        /// <summary>
        /// The standard size of the tiles.
        /// </summary>
        private static readonly Microsoft.Xna.Framework.Point tileSize = Tile.GetTileSize();

        /// <summary>
        /// The standard color mask to apply to all tiles.
        /// </summary>
        private static readonly Microsoft.Xna.Framework.Color colorMask = Microsoft.Xna.Framework.Color.White;

        /// <summary>
        /// Draws the screen.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawScreen(ref SpriteBatch spBatch)
        {
            if (World.mainWorld != null)
            {
                DrawMap(ref spBatch);
            }

            DrawGUI(ref spBatch);

            DrawMouseLocation(ref spBatch);
        }

        public static void DrawMouseLocation(ref SpriteBatch spBatch)
        {
            int x = Mouse.GetState().X;
            int y = Mouse.GetState().Y;
            string mouseLocation = "{ " + x + ", " + y + " }";
            //DrawString(MainMenuLayout.MainMenuFont, mouseLocation, new Rectangle(500, 500, 200, 50), Alignment.Center, Color.AliceBlue, ref spBatch);
        }

        /// <summary>
        /// Draws the GUI onto the screen.
        /// </summary>
        /// <param name="spBatch"></param>
        private static void DrawGUI(ref SpriteBatch spBatch)
        {
            DrawMainMenu(ref spBatch);
        }

        private static void DrawMainMenu(ref SpriteBatch spBatch)
        {
            DrawButton(MainMenu.NewGameButton, ref spBatch);
            DrawButton(MainMenu.QuitButton, ref spBatch);
        }

        private static void DrawButton(MonoButton button, ref SpriteBatch spBatch)
        {
            if (button.Visible)
            {
                spBatch.Draw(button.Image, button.DrawingBounds, colorMask);
                RenderingPipe.DrawString(MainMenuLayout.MainMenuFont, button.Text, button.DrawingBounds, Alignment.Center, colorMask, ref spBatch);
            }
        }

        [Flags]
        public enum Alignment { Center = 0, Left = 1, Right = 2, Top = 4, Bottom = 8 }

        /// <summary>
        /// Slightly modified version of: https://stackoverflow.com/a/10263903/5294414
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="bounds"></param>
        /// <param name="align"></param>
        /// <param name="color"></param>
        /// <param name="spBatch"></param>
        private static void DrawString(SpriteFont font, string text, Microsoft.Xna.Framework.Rectangle bounds, Alignment align, Microsoft.Xna.Framework.Color color, ref SpriteBatch spBatch)
        {
            Vector2 size = font.MeasureString(text);
            Vector2 pos = new Vector2(bounds.Center.X, bounds.Center.Y);
            Vector2 origin = size * 0.5f;

#pragma warning disable RCS1096 // Use bitwise operation instead of calling 'HasFlag'.
            if (align.HasFlag(Alignment.Left))
            {
                origin.X += (bounds.Width / 2) - (size.X / 2);
            }

            if (align.HasFlag(Alignment.Right))
            {
                origin.X -= (bounds.Width / 2) - (size.X / 2);
            }

            if (align.HasFlag(Alignment.Top))
            {
                origin.Y += (bounds.Height / 2) - (size.Y / 2);
            }

            if (align.HasFlag(Alignment.Bottom))
            {
                origin.Y -= (bounds.Height / 2) - (size.Y / 2);
            }
#pragma warning restore RCS1096 // Use bitwise operation instead of calling 'HasFlag'.

            spBatch.DrawString(font, text, pos, color, 0, origin, 1, SpriteEffects.None, 0);
        }

        /// <summary>
        /// Draws the tiles that make up the map.
        /// </summary>
        /// <param name="spBatch"></param>
        private static void DrawMap(ref SpriteBatch spBatch)
        {
            Tile[,,] tiles = World.mainWorld.Tiles;

            int xSize = tiles.GetLength(0);
            int ySize = tiles.GetLength(1);
            int zSize = tiles.GetLength(2);
            int x = 0;
            int y = 0;
            int z = 0;

            while (x < xSize)
            {
                while (y < ySize)
                {
                    while (z < zSize)
                    {
                        Tile tile = tiles[x, y, z];
                        Microsoft.Xna.Framework.Point start = new Microsoft.Xna.Framework.Point(tileSize.X * x, tileSize.Y * y);
                        Microsoft.Xna.Framework.Rectangle target = new Microsoft.Xna.Framework.Rectangle(start, tileSize);
                        spBatch.Draw(AssetManager.Textures[tile.TextureIndex], target, colorMask);
                        z++;
                    }
                    z = 0;
                    y++;
                }
                y = 0;
                x++;
            }
        }
    }
}