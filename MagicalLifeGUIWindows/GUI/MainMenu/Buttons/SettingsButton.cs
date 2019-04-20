using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Settings_Menu;
using MagicalLifeGUIWindows.Properties;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class SettingsButton : MonoButton
    {
        public SettingsButton() : base(TextureLoader.GUIMenuButton, GetLocation(), true, Resources.Settings)
        {
            this.ClickEvent += this.SettingsGameButton_ClickEvent;
        }

        private void SettingsGameButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            SettingsGameMenu.Initialize(true);
            MainMenu.MainMenuID.PopupChild(SettingsGameMenu.Menu);
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.SettingsGameButtonY;

            return new Rectangle(x, y, width, height);
        }

    }
}
