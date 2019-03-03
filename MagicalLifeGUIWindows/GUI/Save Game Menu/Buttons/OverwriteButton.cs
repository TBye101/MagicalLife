using MagicalLifeAPI.Asset;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Save
{
    public class OverwriteButton : MonoButton
    {
        public OverwriteButton() : base(TextureLoader.GUIMenuButton, GetDrawingBounds(), true, "Overwrite Save")
        {
            this.ClickEvent += this.OverwriteButton_ClickEvent;
        }

        private void OverwriteButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
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