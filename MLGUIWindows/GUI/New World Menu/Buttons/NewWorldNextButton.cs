using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeAPI.Properties;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using MagicalLifeClient;
using MagicalLifeGUIWindows.GUI.In;
using MagicalLifeGUIWindows.GUI.MainMenu;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input;
using MagicalLifeGUIWindows.Properties;
using MagicalLifeServer;
using Microsoft.Xna.Framework;
using System;

namespace MagicalLifeGUIWindows.GUI.New
{
    /// <summary>
    /// The next button on the new game form.
    /// </summary>
    public class NewWorldNextButton : MonoButton
    {
        public NewWorldNextButton() : base(TextureLoader.GUIMenuButton, GetLocation(), true, Resources.Next)
        {
            this.ClickEvent += this.NewWorldNextButton_ClickEvent;
        }

        private void NewWorldNextButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            World.Mode = MagicalLifeAPI.Networking.EngineMode.ServerAndClient;
            Server.Load();
            ClientSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(MagicalLifeAPI.Networking.EngineMode.ServerAndClient));
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            FMODUtil.RaiseEvent(SoundsTable.Ambience);
            ServerSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(MagicalLifeAPI.Networking.EngineMode.ServerAndClient));
            Client.Load();
            NewGameInputHandler a = new NewGameInputHandler();
            if (!a.StartNewGame())
            {
                //Should probably make an message box here or something
                return;
            }
            Server.StartGame();
            Guid firstDimensionID = WorldUtil.GetDimensionByName(Lang._1stDimensionName).Key;
            RenderInfo.Camera2D.InitializeForDimension(firstDimensionID);
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