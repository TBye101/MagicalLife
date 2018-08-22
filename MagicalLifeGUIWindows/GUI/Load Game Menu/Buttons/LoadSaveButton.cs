using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeClient;
using MagicalLifeGUIWindows.GUI.In;
using MagicalLifeGUIWindows.GUI.New;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Reusable.API;
using MagicalLifeGUIWindows.Input;
using MagicalLifeServer;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Load_Game_Menu.Buttons
{
    public class LoadSaveButton : MonoButton
    {
        public LoadSaveButton() : base("MenuButton", GetDisplayArea(), true, "Load Save")
        {
        }

        private static Rectangle GetDisplayArea()
        {
            int x = LoadGameMenuLayout.LoadSaveButtonX;
            int y = LoadGameMenuLayout.LoadSaveButtonY;
            int width = LoadGameMenuLayout.LoadSaveButtonWidth;
            int height = LoadGameMenuLayout.LoadSaveButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            int selected = LoadGameMenu.Menu.SaveSelectListBox.SelectedIndex;
            if (selected != -1)
            {
                FMODUtil.RaiseEvent(EffectsTable.UIClick);
                World.Mode = MagicalLifeAPI.Networking.EngineMode.ServerAndClient;
                RenderableString selectedItem = (RenderableString)LoadGameMenu.Menu.SaveSelectListBox.Items[selected];
                WorldStorage.LoadWorld(selectedItem.Text);

                Server.Load();
                ClientSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings());
                ServerSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings());
                Client.Load();
                Server.StartGame();
                BoundHandler.RemoveContainer(LoadGameMenu.Menu);
                MenuHandler.Clear();
                BoundHandler.HideAll();
                InGameGUI.Initialize();
                BoundHandler.Popup(InGameGUI.InGame);
            }
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            // Single click is good enough
        }
    }
}
