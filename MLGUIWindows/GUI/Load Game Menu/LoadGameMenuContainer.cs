using MLAPI.Asset;
using MLAPI.Visual.Rendering;
using MLGUIWindows.GUI.Load_Game_Menu.Buttons;
using MLGUIWindows.GUI.Load_Game_Menu.List_Boxes;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.Load_Game_Menu
{
    public class LoadGameMenuContainer : GuiContainer
    {
        public SelectGameListBox SaveSelectListBox { get; private set; } = new SelectGameListBox();
        public LoadSaveButton LoadSaveButton { get; private set; } = new LoadSaveButton();

        public LoadGameMenuContainer() : base(TextureLoader.GUIMenuBackground, RenderInfo.FullScreenWindow, false)
        {
            this.Controls.Add(this.SaveSelectListBox);
            this.Controls.Add(this.LoadSaveButton);
        }

        public override string GetTextureName()
        {
            return TextureLoader.GUIMenuBackground;
        }
    }
}