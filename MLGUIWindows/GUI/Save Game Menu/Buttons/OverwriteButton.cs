using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.World.Data.Disk;
using MLAPI.World.Data.Disk.DataStorage;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.Save_Game_Menu.Buttons
{
    public class OverwriteButton : MonoButton
    {
        public OverwriteButton() : base(TextureLoader.GUIMenuButton, GetDrawingBounds(), true, Resources.OverwriteSave)
        {
            this.ClickEvent += this.OverwriteButton_ClickEvent;
        }

        private void OverwriteButton_ClickEvent(object sender, ClickEventArgs e)
        {
            this.Overwrite();
        }

        private static Rectangle GetDrawingBounds()
        {
            int x = SaveGameMenuLayout.OverwriteButtonX;
            int y = SaveGameMenuLayout.OverwriteButtonY;
            int width = SaveGameMenuLayout.OverwriteButtonWidth;
            int height = SaveGameMenuLayout.OverwriteButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        private void Overwrite()
        {
            int selected = SaveGameMenu.menu.SavesList.SelectedIndex;

            if (selected != -1)
            {
                RenderableString selectedItem = (RenderableString)SaveGameMenu.menu.SavesList.Items[selected];
                WorldStorage.SerializeWorld(selectedItem.Text, new WorldDiskSink());
            }
            MenuHandler.Back();
        }
    }
}