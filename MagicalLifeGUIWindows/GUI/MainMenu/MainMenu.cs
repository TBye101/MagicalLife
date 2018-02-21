using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.MainMenu
{
    /// <summary>
    /// Holds the controls for the main menu.
    /// </summary>
    public static class MainMenu
    {
        static MainMenu()
        {
        }

        public static void Initialize()
        {
            //NewGameButton = new MonoButton("MenuButton", GetNewGameButtonLocation(), "New Game");
        }

        public static MonoButton NewGameButton { get; private set; }
    }
}