using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Character_Menu.Buttons
{
    /// <summary>
    /// Moves the character menu to the inventory section.
    /// </summary>
    public class SkillsTabButton : MonoButton
    {
        public SkillsTabButton()
            : base(TextureLoader.GUIMenuButton, CharacterMenuLayout.GetSkillsButtonBounds(),
                  true, TextureLoader.FontMainMenuFont12x, "Skills Tab")
        {
            this.ClickEvent += this.SkillsTabButton_ClickEvent;
        }

        private void SkillsTabButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            CharacterMenu.Menu.HideAllControls();
            //Show the inventory menu.
            CharacterMenu.Menu.X.Visible = true;
            CharacterMenu.Menu.Skills.Visible = true;
            CharacterMenu.Menu.CharacterName.Visible = true;
            CharacterMenu.Menu.SkillsButton.Visible = true;
            CharacterMenu.Menu.InventoryButton.Visible = true;
        }
    }
}