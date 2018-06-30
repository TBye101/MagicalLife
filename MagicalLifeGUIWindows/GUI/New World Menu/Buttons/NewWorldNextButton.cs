using MagicalLifeAPI.Networking.Server;
using MagicalLifeClient;
using MagicalLifeGUIWindows.GUI.MainMenu;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input;
using MagicalLifeServer;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu.Buttons
{
    /// <summary>
    /// The next button on the new game form.
    /// </summary>
    public class NewWorldNextButton : MonoButton
    {
        public NewWorldNextButton() : base("MenuButton", GetLocation(), true, "Next")
        {
        }

        public override void Click(MouseEventArgs e)
        {
            ServerSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(MagicalLifeAPI.Networking.EngineMode.ServerAndClient));
            Server.Load(MagicalLifeAPI.Networking.EngineMode.ServerAndClient);
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