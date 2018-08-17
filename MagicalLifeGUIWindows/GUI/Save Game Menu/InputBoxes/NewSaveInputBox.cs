using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Save_Game_Menu.InputBoxes
{
    public class NewSaveInputBox : MonoInputBox
    {
        public NewSaveInputBox() : 
            base("InputBox100x50", "CursorCarrot", GetInitialLocation(), int.MaxValue, "MainMenuFont12x",
                false, SimpleTextRenderer.Alignment.Left, true)
        {
        }

        private static Rectangle GetInitialLocation()
        {
            int x = SaveGameMenuLayout.NewSaveInputBoxX;
            int y = SaveGameMenuLayout.NewSaveInputBoxY;
            int width = SaveGameMenuLayout.NewSaveInputBoxWidth;
            int height = SaveGameMenuLayout.NewSaveInputBoxHeight;

            return new Rectangle(x, y, width, height);
        }
    }
}
