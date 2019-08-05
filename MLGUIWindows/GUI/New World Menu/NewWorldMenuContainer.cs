using MLAPI.Asset;
using MLAPI.Visual.Rendering;
using MLGUIWindows.GUI.New_World_Menu.Buttons;
using MLGUIWindows.GUI.New_World_Menu.Input_Boxes;
using MLGUIWindows.GUI.New_World_Menu.Labels;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.New_World_Menu
{
    /// <summary>
    /// The menu that pops up when the user creates a new world.
    /// </summary>
    public class NewWorldMenuContainer : GuiContainer
    {
        public WorldWidthInputBox WorldWidth { get; } = new WorldWidthInputBox(false);
        public WorldLengthInputBox WorldLength { get; } = new WorldLengthInputBox(false);
        public NewWorldNextButton NextButton { get; } = new NewWorldNextButton();
        public LengthLabel LengthLabel { get; } = new LengthLabel();
        public WidthLabel WidthLabel { get; } = new WidthLabel();
        public MonoInputBox GameName { get; private set; }

        public NewWorldMenuContainer(bool visible) : base(TextureLoader.GuiMenuBackground, RenderInfo.FullScreenWindow, false)
        {
            this.Visible = visible;

            this.GameName = new MonoInputBox(TextureLoader.GuiInputBox100X50, TextureLoader.GuiCursorCarrot, NewWorldMenuLayout.GameNameInputBox,
      int.MaxValue, TextureLoader.FontMainMenuFont12X, false,
      SimpleTextRenderer.Alignment.Left, true);

            this.Controls.Add(this.WorldWidth);
            this.Controls.Add(this.WorldLength);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.GameName);
        }

        public NewWorldMenuContainer() : base()
        {
        }

        public override string GetTextureName()
        {
            return TextureLoader.GuiMenuBackground;
        }
    }
}