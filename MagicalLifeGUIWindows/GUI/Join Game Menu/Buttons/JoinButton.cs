using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Data;
using MagicalLifeClient;
using MagicalLifeGUIWindows.GUI.In;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Join
{
    public class JoinButton : MonoButton
    {
        public JoinButton() : base(TextureLoader.GUIMenuBackground, GetDisplayArea(), true, "Join Game")
        {
            this.ClickEvent += this.JoinButton_ClickEvent;
        }

        private void JoinButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            World.Mode = MagicalLifeAPI.Networking.EngineMode.ClientOnly;
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            ClientSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(JoinGameMenu.Menu.IpInputBox.Text, int.Parse(JoinGameMenu.Menu.PortInputBox.Text)));
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