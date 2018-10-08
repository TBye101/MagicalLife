using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.In
{
    public class BackButton : MonoButton
    {
        public BackButton() : base(TextureLoader.GUIMenuButton, GetDisplayArea(), true, "Back")
        {
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameEscapeMenuLayout.ButtonX;
            int y = InGameEscapeMenuLayout.BackButtonY;
            int width = InGameEscapeMenuLayout.ButtonWidth;
            int height = InGameEscapeMenuLayout.ButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            MenuHandler.Clear();
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            MenuHandler.Clear();
        }
    }
}