using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.Save
{
    public class NewSaveInputBox : MonoInputBox
    {
        public NewSaveInputBox() :
            base(TextureLoader.GUIInputBox100x50, TextureLoader.GUICursorCarrot, GetInitialLocation(), int.MaxValue, TextureLoader.FontMainMenuFont12x,
                false, SimpleTextRenderer.Alignment.Left, true)
        {
        }

        private static Rectangle GetInitialLocation()
        {
            int x = SaveGameMenuLayout.NewSaveInputBoxX;
            int y = SaveGameMenuLayout.NewSaveInputBoxY;
            int width = SaveGameMenuLayout.NewSaveInputBoxWidth;
            int height = SaveGameMenuLayout.NewSaveInputBoxHeight;

            return new Rectangle(x, y, width, height);
        }
    }
}