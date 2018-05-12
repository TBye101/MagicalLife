using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeNetworking.Client;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Join_Game_Menu.Buttons
{
    public class JoinButton : MonoButton
    {
        public JoinButton() : base("MenuButton", GetDisplayArea(), "Join Game")
        {
        }

        private static Rectangle GetDisplayArea()
        {
            int x = JoinGameMenuLayout.JoinButtonX;
            int y = JoinGameMenuLayout.IPInputBoxY;
            int width = JoinGameMenuLayout.IPInputBoxWidth;
            int height = JoinGameMenuLayout.IPInputBoxHeight;
            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e)
        {
            ClientSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(JoinGameMenu.menu.IpInputBox.Text, int.Parse(JoinGameMenu.menu.PortInputBox.Text)));
        }

        public override void DoubleClick(MouseEventArgs e)
        {
        }
    }
}
