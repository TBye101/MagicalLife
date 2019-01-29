using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            CharacterMenu.Menu.HideAllControls();
            //Show the inventory menu.
            CharacterMenu.Menu.X.Visible = true;
            CharacterMenu.Menu.CharacterName.Visible = true;
            CharacterMenu.Menu.SkillsButton.Visible = true;
            CharacterMenu.Menu.InventoryButton.Visible = true;
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
        }
    }
}
