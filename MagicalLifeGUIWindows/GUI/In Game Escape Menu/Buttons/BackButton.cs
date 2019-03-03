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
            this.ClickEvent += this.BackButton_ClickEvent;
        }

        private void BackButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            MenuHandler.Clear();
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameEscapeMenuLayout.ButtonX;
            int y = InGameEscapeMenuLayout.BackButtonY;
            int width = InGameEscapeMenuLayout.ButtonWidth;
            int height = InGameEscapeMenuLayout.ButtonHeight;

            return new Rectangle(x, y, width, height);
        }
    }
}