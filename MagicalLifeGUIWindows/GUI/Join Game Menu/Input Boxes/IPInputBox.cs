using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.Join
{
    public class IPInputBox : MonoInputBox
    {
        public IPInputBox(bool isLocked)
            : base(TextureLoader.GUIInputBox100x50, TextureLoader.GUICursorCarrot, GetInitialLocation(),
                  int.MaxValue, TextureLoader.FontMainMenuFont12x, isLocked, Rendering.Text.SimpleTextRenderer.Alignment.Left, true)
        {
        }

        private static Rectangle GetInitialLocation()
        {
            int x = JoinGameMenuLayout.IPInputBoxX;
            int y = JoinGameMenuLayout.IPInputBoxY;
            int width = JoinGameMenuLayout.IPInputBoxWidth;
            int height = JoinGameMenuLayout.IPInputBoxHeight;
            return new Rectangle(x, y, width, height);
        }
    }
}