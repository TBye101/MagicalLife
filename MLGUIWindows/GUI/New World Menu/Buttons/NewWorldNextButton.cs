using System;
using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Networking;
using MLAPI.Networking.Client;
using MLAPI.Networking.Server;
using MLAPI.Properties;
using MLAPI.Sound;
using MLAPI.Visual.Rendering;
using MLAPI.World;
using MLAPI.World.Data;
using MLClient;
using MLGUIWindows.GUI.In_Game_GUI;
using MLGUIWindows.GUI.MainMenu;
using MLGUIWindows.Input;
using MLGUIWindows.Properties;
using MLServer;
using MonoGUI.MonoGUI;
using MonoGUI.MonoGUI.Input;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.New_World_Menu.Buttons
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

        private void NewWorldNextButton_ClickEvent(object sender, ClickEventArgs e)
        {
            World.Mode = EngineMode.ServerAndClient;
            Server.Load();
            ClientSendRecieve.Initialize(new NetworkSettings(EngineMode.ServerAndClient));
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            FMODUtil.RaiseEvent(SoundsTable.Ambience);
            ServerSendRecieve.Initialize(new NetworkSettings(EngineMode.ServerAndClient));
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
            InputHandlers.MapLoadInitialize();
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