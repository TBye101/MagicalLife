using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class JoinGameButton : MonoButton
    {
        public JoinGameButton() : base("MenuButton", GetLocation(), "Join Game")
        {
        }

        public override void Click(MouseEventArgs e)
        {
            Join_Game_Menu.JoinGameMenu.Initialize();
        }

        public override void DoubleClick(MouseEventArgs e)
        {
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