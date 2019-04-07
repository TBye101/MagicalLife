using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeClient;
using MagicalLifeGUIWindows.GUI.Action_Menu;
using MagicalLifeGUIWindows.GUI.In;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input;
using MagicalLifeServer;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Load
{
    public class LoadSaveButton : MonoButton
    {
        public LoadSaveButton() : base(TextureLoader.GUIMenuButton, GetDisplayArea(), true, "Load Save")
        {
            this.ClickEvent += this.LoadSaveButton_ClickEvent;
        }

        private void LoadSaveButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            int selected = LoadGameMenu.Menu.SaveSelectListBox.SelectedIndex;
            if (selected != -1)
            {
                FMODUtil.RaiseEvent(SoundsTable.UIClick);
                World.Mode = MagicalLifeAPI.Networking.EngineMode.ServerAndClient;
                RenderableString selectedItem = (RenderableString)LoadGameMenu.Menu.SaveSelectListBox.Items[selected];
                WorldStorage.LoadWorld(selectedItem.Text);

                Server.Load();
                ClientSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(MagicalLifeAPI.Networking.EngineMode.ServerAndClient));
                ServerSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(MagicalLifeAPI.Networking.EngineMode.ServerAndClient));
                Client.Load();
                Server.StartGame();
                BoundHandler.RemoveContainer(LoadGameMenu.Menu);
                MenuHandler.Clear();
                BoundHandler.HideAll();
                InGameGUI.Initialize();
                ActionMenu.Initialize();
                BoundHandler.Popup(ActionMenu.AMenu);
                BoundHandler.Popup(InGameGUI.InGame);
                RenderInfo.Camera2D.InitializeForDimension(0);
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