using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeServer.Networking;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Host_Game_Menu.Buttons
{
    /// <summary>
    /// This button starts the process of hosting the game.
    /// </summary>
    public class HostButton : MonoButton
    {
        public HostButton() : base("MenuButton", GetDisplayArea(), "Host Game")
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
            ServerSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(int.Parse(HostGameMenu.menu.HostPortInputBox.Text)));
            MenuHandler.Clear();
        }

        public override void DoubleClick(MouseEventArgs e)
        {
        }
    }
}
