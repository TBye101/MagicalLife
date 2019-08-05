using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Sound;
using MLGUIWindows.GUI.Save_Game_Menu;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.In_Game_Escape_Menu.Buttons
{
    public class SaveButton : MonoButton
    {
        public SaveButton() : base(TextureLoader.GUIMenuButton, GetDisplayArea(), true, Resources.Save)
        {
            this.ClickEvent += this.SaveButton_ClickEvent;
        }

        private void SaveButton_ClickEvent(object sender, ClickEventArgs e)
        {
            this.Save();
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameEscapeMenuLayout.ButtonX;
            int y = InGameEscapeMenuLayout.SaveButtonY;
            int width = InGameEscapeMenuLayout.ButtonWidth;
            int height = InGameEscapeMenuLayout.ButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        private void Save()
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            SaveGameMenu.Initialize();
            InGameEscapeMenu.menu.PopupChild(SaveGameMenu.menu);
        }
    }
}