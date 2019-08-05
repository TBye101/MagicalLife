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
using MLAPI.World.Data.Disk;
using MLClient;
using MLGUIWindows.GUI.In_Game_GUI;
using MLGUIWindows.Input;
using MLGUIWindows.Properties;
using MLServer;
using MonoGUI.MonoGUI;
using MonoGUI.MonoGUI.Input;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.Load_Game_Menu.Buttons
{
    public class LoadSaveButton : MonoButton
    {
        public LoadSaveButton() : base(TextureLoader.GUIMenuButton, GetDisplayArea(), true, Resources.LoadSave)
        {
            this.ClickEvent += this.LoadSaveButton_ClickEvent;
        }

        private void LoadSaveButton_ClickEvent(object sender, ClickEventArgs e)
        {
            int selected = LoadGameMenu.Menu.SaveSelectListBox.SelectedIndex;
            if (selected != -1)
            {
                FMODUtil.RaiseEvent(SoundsTable.UIClick);
                World.Mode = EngineMode.ServerAndClient;
                RenderableString selectedItem = (RenderableString)LoadGameMenu.Menu.SaveSelectListBox.Items[selected];
                WorldStorage.LoadWorld(selectedItem.Text);

                Server.Load();
                ClientSendRecieve.Initialize(new NetworkSettings(EngineMode.ServerAndClient));
                ServerSendRecieve.Initialize(new NetworkSettings(EngineMode.ServerAndClient));
                Client.Load();
                Server.StartGame();
                BoundHandler.RemoveContainer(LoadGameMenu.Menu);
                MenuHandler.Clear();
                BoundHandler.HideAll();
                InGameGUI.Initialize();
                InputHandlers.MapLoadInitialize();
                BoundHandler.Popup(InGameGUI.InGame);
                Guid firstDimensionID = WorldUtil.GetDimensionByName(Lang._1stDimensionName).Key;
                RenderInfo.Camera2D.InitializeForDimension(firstDimensionID);
            }
        }

        private static Rectangle GetDisplayArea()
        {
            int x = LoadGameMenuLayout.LoadSaveButtonX;
            int y = LoadGameMenuLayout.LoadSaveButtonY;
            int width = LoadGameMenuLayout.LoadSaveButtonWidth;
            int height = LoadGameMenuLayout.LoadSaveButtonHeight;

            return new Rectangle(x, y, width, height);
        }
    }
}