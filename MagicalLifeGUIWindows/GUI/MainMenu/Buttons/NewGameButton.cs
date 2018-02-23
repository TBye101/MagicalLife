using MagicalLifeAPI.World;
using MagicalLifeAPI.World.World_Generation.Generators;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class NewGameButton : MonoButton
    {
        public NewGameButton() : base("MenuButton", GetLocation(), "New Game")
        {

        }

        public override void Click(MouseEventArgs e)
        {
            World.Initialize(5, 5, 1, new Dirtland());
        }

        public override void DoubleClick(MouseEventArgs e)
        {
            World.Initialize(5, 5, 1, new Dirtland());
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.NewGameButtonY;

            return new Rectangle(x, y, width, height);
        }
    }
}
