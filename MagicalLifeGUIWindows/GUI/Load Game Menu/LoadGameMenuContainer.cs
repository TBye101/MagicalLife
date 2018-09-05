using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering;

namespace MagicalLifeGUIWindows.GUI.Load
{
    public class LoadGameMenuContainer : GUIContainer
    {
        public SelectGameListBox SaveSelectListBox { get; private set; } = new SelectGameListBox();
        public LoadSaveButton LoadSaveButton { get; private set; } = new LoadSaveButton();

        public LoadGameMenuContainer() : base("MenuBackground", RenderingPipe.FullScreenWindow)
        {
            this.Controls.Add(this.SaveSelectListBox);
            this.Controls.Add(this.LoadSaveButton);
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}