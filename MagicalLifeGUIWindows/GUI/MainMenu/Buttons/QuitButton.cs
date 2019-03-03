using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class QuitButton : MonoButton
    {
        public QuitButton() : base(TextureLoader.GUIMenuButton, GetLocation(), true, "Quit")
        {
            this.ClickEvent += this.QuitButton_ClickEvent;
        }

        private void QuitButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            UniversalEvents.GameExitHandler();
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.QuitButtonY;

            return new Rectangle(x, y, width, height);
        }
    }
}