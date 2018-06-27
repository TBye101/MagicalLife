using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeGUIWindows.GUI.New_World_Menu;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Host_Game_Menu.Buttons
{
    /// <summary>
    /// This button starts the process of hosting the game.
    /// </summary>
    public class HostButton : MonoButton
    {
        public HostButton() : base("MenuButton", GetDisplayArea(), true, "Host Game")
        {
        }

        private static Rectangle GetDisplayArea()
        {
            int x = HostGameMenuLayout.HostGameButtonX;
            int y = HostGameMenuLayout.PortInputBoxY;
            int width = HostGameMenuLayout.InputBoxWidth;
            int height = HostGameMenuLayout.InputBoxHeight;
            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e)
        {
            int port = int.Parse(HostGameMenu.menu.HostPortInputBox.Text);
            ServerSendRecieve.Initialize(new NetworkSettings(port));
            ClientSendRecieve.Initialize(new NetworkSettings(ServerSendRecieve.TCPServer.Server.GetListeningIPs()[0].ToString(), port));
            NewWorldMenu.Initialize();
            MenuHandler.Clear();
        }

        public override void DoubleClick(MouseEventArgs e)
        {
        }
    }
}