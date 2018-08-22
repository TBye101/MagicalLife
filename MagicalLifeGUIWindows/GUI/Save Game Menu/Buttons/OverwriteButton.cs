using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Reusable.API;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Save_Game_Menu.Buttons
{
    public class OverwriteButton : MonoButton
    {
        public OverwriteButton() : base("MenuButton", GetDrawingBounds(), true, "Overwrite Save")
        {
        }

        private static Rectangle GetDrawingBounds()
        {
            int x = SaveGameMenuLayout.OverwriteButtonX;
            int y = SaveGameMenuLayout.OverwriteButtonY;
            int width = SaveGameMenuLayout.OverwriteButtonWidth;
            int height = SaveGameMenuLayout.OverwriteButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            this.Overwrite();
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

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            this.Overwrite();
        }
    }
}