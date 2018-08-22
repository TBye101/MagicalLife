using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Data;
using MagicalLifeClient;
using MagicalLifeGUIWindows.GUI.In;
using MagicalLifeGUIWindows.GUI.MainMenu;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input;
using MagicalLifeServer;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.New
{
    /// <summary>
    /// The next button on the new game form.
    /// </summary>
    public class NewWorldNextButton : MonoButton
    {
        public NewWorldNextButton() : base("MenuButton", GetLocation(), true, "Next")
        {
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            World.Mode = MagicalLifeAPI.Networking.EngineMode.ServerAndClient;
            Server.Load();
            ClientSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings());
            FMODUtil.RaiseEvent(EffectsTable.UIClick);
            ServerSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings());
            Client.Load();
            NewGameInputHandler a = new NewGameInputHandler();
            a.StartNewGame();
            Server.StartGame();
            BoundHandler.RemoveContainer(NewWorldMenu.NewWorldMenuM);
            MenuHandler.Clear();
            BoundHandler.HideAll();
            InGameGUI.Initialize();
            BoundHandler.Popup(InGameGUI.InGame);
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
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