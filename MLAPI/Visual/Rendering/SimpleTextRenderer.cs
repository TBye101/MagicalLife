using MagicalLifeAPI.Filing.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MagicalLifeGUIWindows.Rendering.Text
{
    /// <summary>
    /// Handles simple text rendering.
    /// </summary>
    public static class SimpleTextRenderer
    {
        [Flags]
        public enum Alignment { Center = 0, Left = 1, Right = 2, Top = 4, Bottom = 8 }

        /// <summary>
        /// Determines how much of the "text" can be rendered before it goes out of "bounds".
        /// </summary>
        /// <param name="font">The font the text will be rendered with.</param>
        /// <param name="text">The full text that is attempting to be rendered.</param>
        /// <param name="bounds">The bounds that the text may be drawed in.</param>
        /// <returns></returns>
        public static string GetDrawableText(SpriteFont font, string text, Rectangle bounds)
        {
            int lastPassing = -1;
            int length = text.Length;
            for (int i = 0; i < length; i++)
            {
                Vector2 result = font.MeasureString(text.Substring(0, i + 1));

                if (result.X > 0 && result.X < bounds.Width)
                {
                    lastPassing = i;
                }
            }

            if (lastPassing == -1 && text != string.Empty)
            {
                if (lastPassing == -1)
                {
                    MasterLog.DebugWriteLine("lastPassing = -1");
                }
                throw new ArgumentException("Cannot possibly draw string in allotted space.");
            }
            else
            {
                return text.Substring(0, lastPassing + 1);
            }
        }

        /// <summary>
        /// Slightly modified version of: https://stackoverflow.com/a/10263903/5294414
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="bounds"></param>
        /// <param name="align"></param>
        /// <param name="color"></param>
        /// <param name="spBatch"></param>
        public static void DrawString(SpriteFont font, string text, Rectangle bounds, Alignment align,
            Color color, SpriteBatch spBatch, int renderLayer)
        {
            if (text != string.Empty)
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
                spBatch.DrawString(font, GetDrawableText(font, text, bounds), pos, color, 0, origin, 1, SpriteEffects.None, 0);
            }
        }
    }
}