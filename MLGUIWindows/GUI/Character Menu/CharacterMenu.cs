using MagicalLifeAPI.Entity;

namespace MagicalLifeGUIWindows.GUI.Character_Menu
{
    public static class CharacterMenu
    {
        public static CharacterContainer Menu { get; private set; }

        internal static void Initialize(Living creature)
        {
            CharacterContainer mainMenu = new CharacterContainer(creature);
            Menu = mainMenu;
            MenuHandler.DisplayMenu(Menu);
        }
    }
}