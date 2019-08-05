using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Sound;
using MLGUIWindows.GUI.Join_Game_Menu;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.MainMenu.Buttons
{
    public class JoinGameButton : MonoButton
    {
        public JoinGameButton() : base(TextureLoader.GuiMenuButton, GetLocation(), true, Resources.JoinGame)
        {
            this.ClickEvent += this.JoinGameButton_ClickEvent;
        }

        private void JoinGameButton_ClickEvent(object sender, ClickEventArgs e)
        {
            FmodUtil.RaiseEvent(SoundsTable.UiClick);
            JoinGameMenu.Initialize();
            MainMenu.MainMenuId.PopupChild(JoinGameMenu.Menu);
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.JoinGameButtonY;

            return new Rectangle(x, y, width, height);
        }
    }
}