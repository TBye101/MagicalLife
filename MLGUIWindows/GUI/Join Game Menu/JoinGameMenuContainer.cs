using MLAPI.Asset;
using MLAPI.Visual.Rendering;
using MLGUIWindows.GUI.Join_Game_Menu.Buttons;
using MLGUIWindows.GUI.Join_Game_Menu.Input_Boxes;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.Join_Game_Menu
{
    public class JoinGameMenuContainer : GuiContainer
    {
        public JoinButton JoinButton = new JoinButton();
        public IpInputBox IpInputBox = new IpInputBox(false);
        public PortInputBox PortInputBox = new PortInputBox(false);

        public JoinGameMenuContainer() : base(TextureLoader.GuiMenuBackground, RenderInfo.FullScreenWindow, false)
        {
            this.Controls.Add(this.JoinButton);
            this.Controls.Add(this.IpInputBox);
            this.Controls.Add(this.PortInputBox);
        }

        public override string GetTextureName()
        {
            return TextureLoader.GuiMenuBackground;
        }
    }
}