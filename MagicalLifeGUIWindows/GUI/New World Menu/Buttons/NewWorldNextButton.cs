using MagicalLifeGUIWindows.GUI.MainMenu;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu.Buttons
{
    /// <summary>
    /// The next button on the new game form.
    /// </summary>
    public class NewWorldNextButton : MonoButton
    {
        public NewWorldNextButton() : base("MenuButton", GetLocation(), "Next")
        {
        }

        public override void Click(MouseEventArgs e)
        {
            NewGameInputHandler a = new NewGameInputHandler();
            a.StartNewGame();
            BoundHandler.RemoveContainer(NewWorldMenu.NewWorldMenuM);
            MenuHandler.Clear();
            In_Game_GUI.InGameGUI.Initialize();
            BoundHandler.Popup(In_Game_GUI.InGameGUI.InGame);

            MagicalLifeServer.Networking.TCPServer tCPServer = new MagicalLifeServer.Networking.TCPServer();
            tCPServer.Start(5849);
            MagicalLifeClient.Networking.TCPClient tCPClient = new MagicalLifeClient.Networking.TCPClient();
            tCPClient.Start(5849, "localhost");
        }

        public override void DoubleClick(MouseEventArgs e)
        {
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = NewWorldMenuLayout.NextButtonX;
            int y = NewWorldMenuLayout.WorldSizeInputBoxY;

            return new Rectangle(x, y, width, height);
        }
    }
}