using MLAPI.Asset;
using MLAPI.Visual.Rendering;
using MLGUIWindows.GUI.Settings_Menu.Buttons;
using MLGUIWindows.GUI.Settings_Menu.InputBoxes;
using MLGUIWindows.GUI.Settings_Menu.Labels;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.Settings_Menu
{
    public class SettingsGameMenuContainer : GuiContainer
    {
        public SettingsGameMenuContainer(bool fromMainMenu) : base(TextureLoader.GUIMenuBackground, RenderInfo.FullScreenWindow, false)
        {
            this.Controls.Add(new MainMenuButton(fromMainMenu));
            this.Controls.Add(new MasterVolumeInputBox());
            this.Controls.Add(new MasterVolumeLabel());
        }

        public override string GetTextureName()
        {
            return TextureLoader.GUIMenuBackground;
        }
    }
}