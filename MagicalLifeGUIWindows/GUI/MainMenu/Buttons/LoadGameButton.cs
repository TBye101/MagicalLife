using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.GUI.Load;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class LoadGameButton : MonoButton
    {
        public LoadGameButton() : base(TextureLoader.GUIMenuButton, GetLocation(), true, "Load Game")
        {
            this.ClickEvent += this.LoadGameButton_ClickEvent;
        }

        private void LoadGameButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            LoadGameMenu.Initialize();
            MainMenu.MainMenuID.PopupChild(LoadGameMenu.Menu);
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.LoadGameButtonY;

            return new Rectangle(x, y, width, height);
        }
    }
}