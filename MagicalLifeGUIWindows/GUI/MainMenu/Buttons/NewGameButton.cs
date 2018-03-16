using MagicalLifeAPI.World;
using MagicalLifeAPI.World.World_Generation.Generators;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class NewGameButton : MonoButton
    {
        public NewGameButton() : base("MenuButton", GetLocation(), "New Game")
        {
        }

        public override void Click(MouseEventArgs e)
        {
            this.AnyClick();
        }

        public override void DoubleClick(MouseEventArgs e)
        {
            this.AnyClick();
        }

        private void AnyClick()
        {
            New_World_Menu.NewWorldMenu.Initialize();
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.NewGameButtonY;

            return new Rectangle(x, y, width, height);
        }

        public string GetTextureName()
        {
            return "MenuButton";
        }
    }
}