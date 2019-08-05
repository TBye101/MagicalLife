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
    public class NewSaveButton : MonoButton
    {
        public NewSaveButton() : base(TextureLoader.GuiMenuButton, GetDrawingBounds(), true, Resources.NewSave)
        {
            this.ClickEvent += this.NewSaveButton_ClickEvent;
        }

        private void NewSaveButton_ClickEvent(object sender, ClickEventArgs e)
        {
            this.NewSave();
        }

        private static Rectangle GetDrawingBounds()
        {
            int x = SaveGameMenuLayout.NewSaveButtonX;
            int y = SaveGameMenuLayout.NewSaveButtonY;
            int width = SaveGameMenuLayout.NewSaveButtonWidth;
            int height = SaveGameMenuLayout.NewSaveButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        private void NewSave()
        {
            if (!string.IsNullOrWhiteSpace(SaveGameMenu.Menu.SaveInputBox.Text))
            {
                WorldStorage.SerializeWorld(SaveGameMenu.Menu.SaveInputBox.Text, new WorldDiskSink());
            }
            MenuHandler.Back();
        }
    }
}