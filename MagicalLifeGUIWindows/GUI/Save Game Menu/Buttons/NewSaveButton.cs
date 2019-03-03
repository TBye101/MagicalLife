using MagicalLifeAPI.Asset;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Save
{
    public class NewSaveButton : MonoButton
    {
        public NewSaveButton() : base(TextureLoader.GUIMenuButton, GetDrawingBounds(), true, "New Save")
        {
            this.ClickEvent += this.NewSaveButton_ClickEvent;
        }

        private void NewSaveButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
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
            if (SaveGameMenu.menu.SaveInputBox.Text != string.Empty)
            {
                WorldStorage.SerializeWorld(SaveGameMenu.menu.SaveInputBox.Text, new WorldDiskSink());
            }
            MenuHandler.Back();
        }
    }
}