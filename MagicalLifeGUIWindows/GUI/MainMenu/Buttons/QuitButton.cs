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
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            UniversalEvents.GameExitHandler();
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
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