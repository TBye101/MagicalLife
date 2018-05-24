using MagicalLifeGUIWindows.GUI.Join_Game_Menu.Buttons;
using MagicalLifeGUIWindows.GUI.Join_Game_Menu.Input_Boxes;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering;

namespace MagicalLifeGUIWindows.GUI.Join_Game_Menu
{
    public class JoinGameMenuContainer : GUIContainer
    {
        public JoinButton JoinButton = new JoinButton();
        public IPInputBox IpInputBox = new IPInputBox(false);
        public PortInputBox PortInputBox = new PortInputBox(false);

        public JoinGameMenuContainer() : base("MenuBackground", RenderingPipe.FullScreenWindow)
        {
            this.Controls.Add(this.JoinButton);
            this.Controls.Add(this.IpInputBox);
            this.Controls.Add(this.PortInputBox);
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}