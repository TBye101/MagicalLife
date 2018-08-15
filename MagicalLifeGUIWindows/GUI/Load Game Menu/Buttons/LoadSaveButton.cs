using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Reusable.API;
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
            int selected = LoadGameMenu.menu.SaveSelectListBox.SelectedIndex;
            if (selected != -1)
            {
                FMODUtil.RaiseEvent(EffectsTable.UIClick);
                RenderableString selectedItem = (RenderableString)LoadGameMenu.menu.SaveSelectListBox.Items[selected];
                WorldStorage.Load(selectedItem.Text);
            }
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            FMODUtil.RaiseEvent(EffectsTable.UIClick);
        }
    }
}
