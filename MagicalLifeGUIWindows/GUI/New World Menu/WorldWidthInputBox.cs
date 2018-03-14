using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu
{
    /// <summary>
    /// Allows the user to input how wide they want the world to be.
    /// </summary>
    public class WorldWidthInputBox : InputBox
    {
        public WorldWidthInputBox(bool isLocked) : base("InputBox100x50", "CursorCarrot", new Rectangle(100, 100, 100, 50), int.MaxValue, "MainMenuFont12x", isLocked, Rendering.Text.SimpleTextRenderer.Alignment.Left)
        {
        }

        public WorldWidthInputBox() : base()
        {
        }

        public string GetTextureName()
        {
            return "CursorCarrot";
        }
    }
}