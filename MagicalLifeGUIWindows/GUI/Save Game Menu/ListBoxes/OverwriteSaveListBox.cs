using MagicalLifeAPI.Filing;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Reusable.API;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Save_Game_Menu.ListBoxes
{
    public class OverwriteSaveListBox : ListBox
    {
        private static readonly SpriteFont ItemFont = Game1.AssetManager.Load<SpriteFont>("MainMenuFont12x");

        public OverwriteSaveListBox() : base(GetDrawingBounds(), 1, true, "MainMenuFont12x", SaveGameMenuLayout.ItemRenderCount, GetAllSaveGames())
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

        private static List<AbstractGUIRenderable> GetAllSaveGames()
        {
            IEnumerable<string> saves = FileSystemManager.GetAllSaveNames();

            List<AbstractGUIRenderable> ret = new List<AbstractGUIRenderable>();
            foreach (string item in saves)
            {
                ret.Add(new RenderableString(ItemFont, item));
            }

            return ret;
        }
    }
}
