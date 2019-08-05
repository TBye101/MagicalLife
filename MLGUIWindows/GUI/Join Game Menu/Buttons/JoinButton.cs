using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Networking;
using MLAPI.Networking.Client;
using MLAPI.Sound;
using MLAPI.World.Data;
using MLClient;
using MLGUIWindows.GUI.In_Game_GUI;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI;
using MonoGUI.MonoGUI.Input;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.Join_Game_Menu.Buttons
{
    public class JoinButton : MonoButton
    {
        public JoinButton() : base(TextureLoader.GUIMenuBackground, GetDisplayArea(), true, Resources.JoinGame)
        {
            this.ClickEvent += this.JoinButton_ClickEvent;
        }

        private void JoinButton_ClickEvent(object sender, ClickEventArgs e)
        {
            World.Mode = EngineMode.ClientOnly;
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            ClientSendRecieve.Initialize(new NetworkSettings(JoinGameMenu.Menu.IpInputBox.Text, int.Parse(JoinGameMenu.Menu.PortInputBox.Text)));
            Client.Load();
            MenuHandler.Clear();
            InGameGUI.Initialize();
            BoundHandler.Popup(InGameGUI.InGame);
        }

        private static Rectangle GetDisplayArea()
        {
            int x = JoinGameMenuLayout.JoinButtonX;
            int y = JoinGameMenuLayout.IPInputBoxY;
            int width = JoinGameMenuLayout.IPInputBoxWidth;
            int height = JoinGameMenuLayout.IPInputBoxHeight;
            return new Rectangle(x, y, width, height);
        }
    }
}