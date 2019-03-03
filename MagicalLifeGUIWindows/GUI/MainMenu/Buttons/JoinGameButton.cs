using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.GUI.Join;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class JoinGameButton : MonoButton
    {
        public JoinGameButton() : base(TextureLoader.GUIMenuButton, GetLocation(), true, "Join Game")
        {
            this.ClickEvent += this.JoinGameButton_ClickEvent;
        }

        private void JoinGameButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            JoinGameMenu.Initialize();
            MainMenu.MainMenuID.PopupChild(JoinGameMenu.Menu);
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