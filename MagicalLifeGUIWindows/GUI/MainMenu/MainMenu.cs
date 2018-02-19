using Microsoft.Xna.Framework;
using MagicalLifeGUIWindows.GUI.Reusable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void Initialize(Game1 window)
        {
            NewGameButton = new MonoButton("MenuButton", GetNewGameButtonLocation(window), "New Game");
        }

        public static MonoButton NewGameButton { get; private set; }

        private static Rectangle GetNewGameButtonLocation(Game1 window)
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.NewGameButtonY;

            return new Rectangle(x, y, width, height);
        }
    }
}
