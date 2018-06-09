using MagicalLifeGUIWindows.GUI.New_World_Menu.Buttons;
using MagicalLifeGUIWindows.GUI.New_World_Menu.Input_Boxes;
using MagicalLifeGUIWindows.GUI.New_World_Menu.Labels;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu
{
    /// <summary>
    /// The menu that pops up when the user creates a new world.
    /// </summary>
    public class NewWorldMenuContainer : GUIContainer
    {
        public WorldWidthInputBox worldWidth = new WorldWidthInputBox(false);
        public WorldLengthInputBox worldLength = new WorldLengthInputBox(false);
        public NewWorldNextButton nextButton = new NewWorldNextButton();
        public LengthLabel lengthLabel = new LengthLabel();
        public WidthLabel widthLabel = new WidthLabel();

        public NewWorldMenuContainer(bool visible) : base("MenuBackground", RenderingPipe.FullScreenWindow)
        {
            this.Visible = visible;
            this.Controls.Add(this.worldWidth);
            this.Controls.Add(this.worldLength);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.widthLabel);
        }

        public NewWorldMenuContainer() : base()
        {
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}