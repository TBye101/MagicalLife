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
    }
}