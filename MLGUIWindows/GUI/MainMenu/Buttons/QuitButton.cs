using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Properties;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class QuitButton : MonoButton
    {
        public QuitButton() : base(TextureLoader.GUIMenuButton, GetLocation(), true, Resources.Quit)
        {
            this.ClickEvent += this.QuitButton_ClickEvent;
        }

        private void QuitButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            Uni.GameExitHandler();
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