using MLAPI.Asset;
using MLAPI.Visual.Rendering;
using MLGUIWindows.GUI.Save_Game_Menu.Buttons;
using MLGUIWindows.GUI.Save_Game_Menu.InputBoxes;
using MLGUIWindows.GUI.Save_Game_Menu.ListBoxes;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.Save_Game_Menu
{
    public class SaveGameMenuContainer : GuiContainer
    {
        public OverwriteSaveListBox SavesList { get; private set; } = new OverwriteSaveListBox();

        public OverwriteButton OverwriteButton { get; private set; } = new OverwriteButton();

        public NewSaveInputBox SaveInputBox { get; private set; } = new NewSaveInputBox();

        public NewSaveButton NewButton { get; private set; } = new NewSaveButton();

        public SaveGameMenuContainer() : base(TextureLoader.GUIMenuBackground, RenderInfo.FullScreenWindow, false)
        {
            this.Controls.Add(this.SavesList);
            this.Controls.Add(this.OverwriteButton);
            this.Controls.Add(this.SaveInputBox);
            this.Controls.Add(this.NewButton);
        }

        public override string GetTextureName()
        {
            return TextureLoader.GUIMenuBackground;
        }
    }
}