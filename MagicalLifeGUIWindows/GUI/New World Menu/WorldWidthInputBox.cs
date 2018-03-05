using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu
{
    /// <summary>
    /// Allows the user to input how wide they want the world to be.
    /// </summary>
    public class WorldWidthInputBox : InputBox
    {
        public WorldWidthInputBox(Texture2D image, Texture2D CarrotTexture, Rectangle drawingBounds, int priority, string font, bool isLocked) : base(image, CarrotTexture, drawingBounds, priority, font, isLocked)
        {
        }
    }
}
