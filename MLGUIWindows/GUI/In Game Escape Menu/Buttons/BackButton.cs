using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.In_Game_Escape_Menu.Buttons
{
    public class BackButton : MonoButton
    {
        public BackButton() : base(TextureLoader.GuiMenuButton, GetDisplayArea(), true, Resources.Back)
        {
            this.ClickEvent += this.BackButton_ClickEvent;
        }

        private void BackButton_ClickEvent(object sender, ClickEventArgs e)
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