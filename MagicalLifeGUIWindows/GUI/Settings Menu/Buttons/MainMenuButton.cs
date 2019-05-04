using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.GUI.MainMenu;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Properties;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.Settings_Menu.Buttons
{
    public class MainMenuButton : MonoButton
    {
        private bool FromMainMenu { get; set; }

        public MainMenuButton(bool fromMainMenu) : base(TextureLoader.GUIMenuButton, GetLocation(), true, Resources.Back)
        {
            this.ClickEvent += this.MainMenuButton_ClickEvent;
            FromMainMenu = fromMainMenu;
        }

        private void MainMenuButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            MenuHandler.Clear();
            if (FromMainMenu)
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