using MagicalLifeClient;
using MagicalLifeGUIWindows.GUI.MainMenu;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input;
using MagicalLifeServer;
using MagicalLifeServer.Networking;
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
            ServerSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(true));
            Server.Load();
            Client.Load();
            Server.StartGame();
            NewGameInputHandler a = new NewGameInputHandler();
            a.StartNewGame();
            BoundHandler.RemoveContainer(NewWorldMenu.NewWorldMenuM);
            MenuHandler.Clear();
            BoundHandler.HideAll();
            In_Game_GUI.InGameGUI.Initialize();
            BoundHandler.Popup(In_Game_GUI.InGameGUI.InGame);
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