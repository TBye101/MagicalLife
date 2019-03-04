using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
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
        public NewWorldNextButton() : base(TextureLoader.GUIMenuButton, GetLocation(), true, "Next")
        {
            this.ClickEvent += this.NewWorldNextButton_ClickEvent;
        }

        private void NewWorldNextButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            World.Mode = MagicalLifeAPI.Networking.EngineMode.ServerAndClient;
            Server.Load();
            ClientSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(MagicalLifeAPI.Networking.EngineMode.ServerAndClient));
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            //FMODUtil.RaiseEvent(SoundsTable.Ambience);
            ServerSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(MagicalLifeAPI.Networking.EngineMode.ServerAndClient));
            Client.Load();
            NewGameInputHandler a = new NewGameInputHandler();
            a.StartNewGame();
            Server.StartGame();
            RenderInfo.Camera2D.InitializeForDimension(0);
            BoundHandler.RemoveContainer(NewWorldMenu.NewWorldMenuM);
            MenuHandler.Clear();
            BoundHandler.HideAll();
            InGameGUI.Initialize();
            BoundHandler.Popup(InGameGUI.InGame);
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