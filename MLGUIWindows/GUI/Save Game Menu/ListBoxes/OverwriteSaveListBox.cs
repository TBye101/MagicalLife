using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLAPI.Asset;
using MLAPI.Filing;
using MLAPI.Visual.Rendering;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Collections;

namespace MLGUIWindows.GUI.Save_Game_Menu.ListBoxes
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
                ret.Add(new RenderableString(ItemFont, item, SimpleTextRenderer.Alignment.Center));
            }

            return ret;
        }
    }
}