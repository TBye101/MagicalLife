using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Save_Game_Menu.Buttons
{
    public class NewSaveButton : MonoButton
    {
        public NewSaveButton() : base("MenuButton", GetDrawingBounds(), true, "New Save")
        {
        }

        private static Rectangle GetDrawingBounds()
        {
            int x = SaveGameMenuLayout.NewSaveButtonX;
            int y = SaveGameMenuLayout.NewSaveButtonY;
            int width = SaveGameMenuLayout.NewSaveButtonWidth;
            int height = SaveGameMenuLayout.NewSaveButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            this.NewSave();
        }

        private void NewSave()
        {
            if (SaveGameMenu.menu.SaveInputBox.Text != string.Empty)
            {
                WorldStorage.SerializeWorld(SaveGameMenu.menu.SaveInputBox.Text, new WorldDiskSink());
            }
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            this.NewSave();
        }
    }
}
