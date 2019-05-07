using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.Character_Menu
{
    /// <summary>
    /// Layout for the character menu.
    /// </summary>
    public static class CharacterMenuLayout
    {
        public static Rectangle GetMenuBounds()
        {
            return new Rectangle(0, 0, 600, 300);
        }

        /// <summary>
        /// The bounds of the name label.
        /// </summary>
        /// <returns></returns>
        public static Rectangle GetNameBounds()
        {
            return new Rectangle(20, 40, 200, 50);
        }

        /// <summary>
        /// The bounds of the skills display list.
        /// </summary>
        /// <returns></returns>
        public static Rectangle GetSkillsBounds()
        {
            return new Rectangle(160, 60, 200, 200);
        }

        /// <summary>
        /// The bounds of the inventory display grid.
        /// </summary>
        /// <returns></returns>
        public static Rectangle GetInventoryBounds()
        {
            return new Rectangle(160, 60, 400, 300);
        }

        /// <summary>
        /// The bounds of the button in the character menu which changes the view to look at the character's inventory.
        /// </summary>
        /// <returns></returns>
        public static Rectangle GetInventoryButtonBounds()
        {
            return new Rectangle(160, 0, 100, 30);
        }

        /// <summary>
        /// The bounds of the button in the character menu which changes the view to look at the character's skills.
        /// </summary>
        /// <returns></returns>
        public static Rectangle GetSkillsButtonBounds()
        {
            return new Rectangle(40, 0, 100, 30);
        }
    }
}