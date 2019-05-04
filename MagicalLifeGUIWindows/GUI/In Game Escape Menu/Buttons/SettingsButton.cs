using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.GUI.In;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Settings_Menu;
using MagicalLifeGUIWindows.Properties;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.In_Game_Escape_Menu.Buttons
{
    public class SettingsButton : MonoButton
    {
        public SettingsButton() : base(TextureLoader.GUIMenuButton, GetDisplayArea(), true, Resources.Settings)
        {
            this.ClickEvent += this.SettingsButton_ClickEvent;
        }

        private void SettingsButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            this.OpenSettingsMenu();
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameEscapeMenuLayout.ButtonX;
            int y = InGameEscapeMenuLayout.SettingsButtonY;
            int width = InGameEscapeMenuLayout.ButtonWidth;
            int height = InGameEscapeMenuLayout.ButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        private void OpenSettingsMenu()
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            SettingsGameMenu.Initialize(false);
            InGameEscapeMenu.menu.PopupChild(SettingsGameMenu.Menu);
        }
    }
}