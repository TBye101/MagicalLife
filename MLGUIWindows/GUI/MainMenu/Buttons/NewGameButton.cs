using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Sound;
using MLGUIWindows.GUI.New_World_Menu;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.MainMenu.Buttons
{
    public class NewGameButton : MonoButton
    {
        public NewGameButton() : base(TextureLoader.GuiMenuButton, GetLocation(), true, Resources.NewGame)
        {
            this.ClickEvent += this.NewGameButton_ClickEvent;
        }

        private void NewGameButton_ClickEvent(object sender, ClickEventArgs e)
        {
            FmodUtil.RaiseEvent(SoundsTable.UiClick);
            NewWorldMenu.Initialize();
            MainMenu.MainMenuId.PopupChild(NewWorldMenu.NewWorldMenuM);
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.NewGameButtonY;

            return new Rectangle(x, y, width, height);
        }

        public string GetTextureName()
        {
            return "MenuButton";
        }
    }
}