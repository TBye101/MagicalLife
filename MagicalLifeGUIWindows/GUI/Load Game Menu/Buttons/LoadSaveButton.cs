using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Load_Game_Menu.Buttons
{
    public class LoadSaveButton : MonoButton
    {
        public LoadSaveButton() : base("MenuButton", GetDisplayArea(), true, "Load Save")
        {
        }

        private static Rectangle GetDisplayArea()
        {
            int x = LoadGameMenuLayout.LoadSaveButtonX;
            int y = LoadGameMenuLayout.LoadSaveButtonY;
            int width = LoadGameMenuLayout.LoadSaveButtonWidth;
            int height = LoadGameMenuLayout.LoadSaveButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            throw new NotImplementedException();
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
