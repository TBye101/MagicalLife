using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering;

namespace MagicalLifeGUIWindows.GUI.Host
{
    public class HostGameMenuContainer : GUIContainer
    {
        public HostButton HostButton = new HostButton();
        public HostPortInputBox HostPortInputBox = new HostPortInputBox(false);

        public HostGameMenuContainer() : base("MenuBackground", RenderingPipe.FullScreenWindow)
        {
            this.Controls.Add(this.HostPortInputBox);
            this.Controls.Add(this.HostButton);
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}