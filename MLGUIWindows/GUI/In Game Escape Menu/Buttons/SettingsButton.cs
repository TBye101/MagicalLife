using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Sound;
using MLGUIWindows.GUI.Settings_Menu;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.In_Game_Escape_Menu.Buttons
{
    public class SettingsButton : MonoButton
    {
        public SettingsButton() : base(TextureLoader.GuiMenuButton, GetDisplayArea(), true, Resources.Settings)
        {
            this.ClickEvent += this.SettingsButton_ClickEvent;
        }

        private void SettingsButton_ClickEvent(object sender, ClickEventArgs e)
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
            FmodUtil.RaiseEvent(SoundsTable.UiClick);
            SettingsGameMenu.Initialize(false);
            InGameEscapeMenu.Menu.PopupChild(SettingsGameMenu.Menu);
        }
    }
}