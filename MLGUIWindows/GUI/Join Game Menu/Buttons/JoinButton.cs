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
        public JoinButton() : base(TextureLoader.GuiMenuBackground, GetDisplayArea(), true, Resources.JoinGame)
        {
            this.ClickEvent += this.JoinButton_ClickEvent;
        }

        private void JoinButton_ClickEvent(object sender, ClickEventArgs e)
        {
            World.Mode = EngineMode.ClientOnly;
            FmodUtil.RaiseEvent(SoundsTable.UiClick);
            ClientSendRecieve.Initialize(new NetworkSettings(JoinGameMenu.Menu.IpInputBox.Text, int.Parse(JoinGameMenu.Menu.PortInputBox.Text)));
            Client.Load();
            MenuHandler.Clear();
            InGameGui.Initialize();
            BoundHandler.Popup(InGameGui.InGame);
        }

        private static Rectangle GetDisplayArea()
        {
            int x = JoinGameMenuLayout.JoinButtonX;
            int y = JoinGameMenuLayout.IpInputBoxY;
            int width = JoinGameMenuLayout.IpInputBoxWidth;
            int height = JoinGameMenuLayout.IpInputBoxHeight;
            return new Rectangle(x, y, width, height);
        }
    }
}