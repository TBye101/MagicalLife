using MagicalLifeAPI.Networking.Client;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class NewGameButton : MonoButton
    {
        public NewGameButton() : base("MenuButton", GetLocation(), true, "New Game")
        {
        }

        public override void Click(MouseEventArgs e)
        {
            New_World_Menu.NewWorldMenu.Initialize();
            ClientSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(MagicalLifeAPI.Networking.EngineMode.ServerAndClient));
        }

        public override void DoubleClick(MouseEventArgs e)
        {
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