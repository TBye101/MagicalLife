using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Save_Game_Menu;
using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.In_Game_Escape_Menu.Buttons
{
    public class SaveButton : MonoButton
    {
        public SaveButton() : base("MenuButton", GetDisplayArea(), true, "Save Game")
        {
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameEscapeMenuLayout.ButtonX;
            int y = InGameEscapeMenuLayout.SaveButtonY;
            int width = InGameEscapeMenuLayout.ButtonWidth;
            int height = InGameEscapeMenuLayout.ButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            this.Save();
        }

        private void Save()
        {
            FMODUtil.RaiseEvent(EffectsTable.UIClick);
            SaveGameMenu.Initialize();
            InGameEscapeMenu.menu.PopupChild(SaveGameMenu.menu);

        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            this.Save();
        }
    }
}
