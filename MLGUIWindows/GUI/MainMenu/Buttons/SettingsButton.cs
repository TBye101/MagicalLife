using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Sound;
using MLGUIWindows.GUI.Settings_Menu;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.MainMenu.Buttons
{
    public class SettingsButton : MonoButton
    {
        public SettingsButton() : base(TextureLoader.GUIMenuButton, GetLocation(), true, Resources.Settings)
        {
            this.ClickEvent += this.SettingsGameButton_ClickEvent;
        }

        private void SettingsGameButton_ClickEvent(object sender, ClickEventArgs e)
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