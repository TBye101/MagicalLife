using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.GUI.Host;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class HostGameButton : MonoButton
    {
        public HostGameButton() : base("MenuButton", GetLocation(), true, "Host Game")
        {
        }

        public override void Click(MouseEventArgs e)
        {
            FMODUtil.RaiseEvent(EffectsTable.UIClick);
            HostGameMenu.Initialize();
        }

        public override void DoubleClick(MouseEventArgs e)
        {
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.HostGameButtonY;

            return new Rectangle(x, y, width, height);
        }
    }
}