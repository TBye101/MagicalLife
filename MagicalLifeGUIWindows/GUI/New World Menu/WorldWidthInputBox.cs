using MagicalLifeAPI.Universal;
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
    public class WorldWidthInputBox : InputBox, IRequireTexture
    {
        public WorldWidthInputBox(bool isLocked) : base("WorldSizeInputBox", "CursorCarrot", new Rectangle(100, 100, 100, 50), int.MaxValue, "MainMenuFont12x", isLocked)
        {
        }

        public WorldWidthInputBox() : base()
        {

        }

        public string GetTextureName()
        {
            return "CursorCarrot";
        }
    }
}
