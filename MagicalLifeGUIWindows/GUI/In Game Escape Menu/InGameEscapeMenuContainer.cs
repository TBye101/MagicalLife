using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering;

namespace MagicalLifeGUIWindows.GUI.In
{
    public class InGameEscapeMenuContainer : GUIContainer
    {
        public QuitButton Quit { get; private set; } = new QuitButton();

        public SaveButton Save { get; private set; } = new SaveButton();

        public BackButton Back { get; private set; } = new BackButton();

        public InGameEscapeMenuContainer() : base("MenuBackground", RenderingPipe.FullScreenWindow)
        {
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Back);
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}