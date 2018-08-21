using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.GUI.New;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class NewGameButton : MonoButton
    {
        public NewGameButton() : base("MenuButton", GetLocation(), true, "New Game")
        {
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            FMODUtil.RaiseEvent(EffectsTable.UIClick);
            NewWorldMenu.Initialize();
            MainMenu.MainMenuID.PopupChild(NewWorldMenu.NewWorldMenuM);
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
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