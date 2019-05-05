using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Filing;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.GUI.Save
{
    public class OverwriteSaveListBox : ListBox
    {
        private static readonly SpriteFont ItemFont = Game1.AssetManager.Load<SpriteFont>(TextureLoader.FontMainMenuFont12x);

        public OverwriteSaveListBox() : base(GetDrawingBounds(), 1, true, TextureLoader.FontMainMenuFont12x, SaveGameMenuLayout.ItemRenderCount, GetAllSaveGames())
        {
        }

        private static Rectangle GetDrawingBounds()
        {
            int x = SaveGameMenuLayout.OverwriteSaveListBoxX;
            int y = SaveGameMenuLayout.OverwriteSaveListBoxY;
            int width = SaveGameMenuLayout.OverwriteSaveBoxWidth;
            int height = SaveGameMenuLayout.OverwriteSaveBoxHeight;

            return new Rectangle(x, y, width, height);
        }

        private static List<GUIElement> GetAllSaveGames()
        {
            IEnumerable<string> saves = FileSystemManager.GetAllSaveNames();

            List<GUIElement> ret = new List<GUIElement>();
            foreach (string item in saves)
            {
                ret.Add(new RenderableString(ItemFont, item, Rendering.Text.SimpleTextRenderer.Alignment.Center));
            }

            return ret;
        }
    }
}