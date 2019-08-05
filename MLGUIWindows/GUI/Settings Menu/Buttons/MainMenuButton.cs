using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Sound;
using MLGUIWindows.GUI.MainMenu;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.Settings_Menu.Buttons
{
    public class MainMenuButton : MonoButton
    {
        private bool FromMainMenu { get; set; }

        public MainMenuButton(bool fromMainMenu) : base(TextureLoader.GuiMenuButton, GetLocation(), true, Resources.Back)
        {
            this.ClickEvent += this.MainMenuButton_ClickEvent;
            this.FromMainMenu = fromMainMenu;
        }

        private void MainMenuButton_ClickEvent(object sender, ClickEventArgs e)
        {
            FmodUtil.RaiseEvent(SoundsTable.UiClick);
            MenuHandler.Clear();
            if (this.FromMainMenu)
            {
                MainMenu.MainMenu.Initialize();
            }
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = SettingsMenuLayout.MainMenuButtonY;

            return new Rectangle(x, y, width, height);
        }
    }
}