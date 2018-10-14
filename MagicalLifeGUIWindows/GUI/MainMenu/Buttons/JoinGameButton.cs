using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.GUI.Join;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.MainMenu.Buttons
{
    public class JoinGameButton : MonoButton
    {
        public JoinGameButton() : base(TextureLoader.GUIMenuButton, GetLocation(), true, "Join Game")
        {
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            FMODUtil.RaiseEvent(EffectsTable.UIClick);
            JoinGameMenu.Initialize();
            MainMenu.MainMenuID.PopupChild(JoinGameMenu.menu);
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            //Single click is good enough for now
        }

        private static Rectangle GetLocation()
        {
            int width = MainMenuLayout.ButtonWidth;
            int height = MainMenuLayout.ButtonHeight;
            int x = MainMenuLayout.ButtonX;
            int y = MainMenuLayout.JoinGameButtonY;

            return new Rectangle(x, y, width, height);
        }
    }
}