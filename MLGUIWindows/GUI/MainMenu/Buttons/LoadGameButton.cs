using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Sound;
using MLGUIWindows.GUI.Load_Game_Menu;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.MainMenu.Buttons
{
    public class LoadGameButton : MonoButton
    {
        public LoadGameButton() : base(TextureLoader.GuiMenuButton, GetLocation(), true, Resources.LoadGame)
        {
            this.ClickEvent += this.LoadGameButton_ClickEvent;
        }

        private void LoadGameButton_ClickEvent(object sender, ClickEventArgs e)
        {
            FmodUtil.RaiseEvent(SoundsTable.UiClick);
            LoadGameMenu.Initialize();
            MainMenu.MainMenuId.PopupChild(LoadGameMenu.Menu);
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.LoadGameButtonY;

            return new Rectangle(x, y, width, height);
        }
    }
}