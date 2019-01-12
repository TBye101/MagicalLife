using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeGUIWindows.GUI.Reusable;

namespace MagicalLifeGUIWindows.GUI.Save
{
    public class SaveGameMenuContainer : GUIContainer
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