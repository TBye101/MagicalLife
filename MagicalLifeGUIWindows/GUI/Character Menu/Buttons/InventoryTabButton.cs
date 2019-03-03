using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Character_Menu.Buttons
{
    /// <summary>
    /// Moves the character menu to the inventory section.
    /// </summary>
    public class InventoryTabButton : MonoButton
    {
        public InventoryTabButton()
            : base(TextureLoader.GUIMenuButton, CharacterMenuLayout.GetInventoryButtonBounds(),
                  true, TextureLoader.FontMainMenuFont12x, "Inventory Tab")
        {
            this.ClickEvent += this.InventoryTabButton_ClickEvent;
        }

        private void InventoryTabButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            CharacterMenu.Menu.HideAllControls();
            //Show the inventory menu.
            CharacterMenu.Menu.X.Visible = true;
            CharacterMenu.Menu.CharacterName.Visible = true;
            CharacterMenu.Menu.SkillsButton.Visible = true;
            CharacterMenu.Menu.InventoryButton.Visible = true;
            CharacterMenu.Menu.Inventory.Visible = true;
        }
    }
}