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
        }

        private static Rectangle GetDrawingBounds()
        {
            int x = SaveGameMenuLayout.NewSaveButtonX;
            int y = SaveGameMenuLayout.NewSaveButtonY;
            int width = SaveGameMenuLayout.NewSaveButtonWidth;
            int height = SaveGameMenuLayout.NewSaveButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            this.NewSave();
        }

        private void NewSave()
        {
            if (SaveGameMenu.menu.SaveInputBox.Text != string.Empty)
            {
                WorldStorage.SerializeWorld(SaveGameMenu.menu.SaveInputBox.Text, new WorldDiskSink());
            }
            MenuHandler.Back();
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            this.NewSave();
        }
    }
}