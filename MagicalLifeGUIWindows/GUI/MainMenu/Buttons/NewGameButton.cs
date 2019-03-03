using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.GUI.New;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class NewGameButton : MonoButton
    {
        public NewGameButton() : base(TextureLoader.GUIMenuButton, GetLocation(), true, "New Game")
        {
            this.ClickEvent += this.NewGameButton_ClickEvent;
        }

        private void NewGameButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            NewWorldMenu.Initialize();
            MainMenu.MainMenuID.PopupChild(NewWorldMenu.NewWorldMenuM);
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