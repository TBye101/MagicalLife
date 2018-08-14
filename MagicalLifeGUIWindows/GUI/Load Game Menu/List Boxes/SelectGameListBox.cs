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

namespace MagicalLifeGUIWindows.GUI.Load_Game_Menu.List_Boxes
{
    public class SelectGameListBox : ListBox
    {
        private static SpriteFont ItemFont = Game1.AssetManager.Load<SpriteFont>("MainMenuFont12x");

        public SelectGameListBox() : base(GetDrawingBounds(), 1, true, "MainMenuFont12x", LoadGameMenuLayout.ItemRenderCount, GetAllSaveGames())
        {
        }

        private static Rectangle GetDrawingBounds()
        {
            int x = LoadGameMenuLayout.LoadSaveListBoxX;
            int y = LoadGameMenuLayout.LoadSaveListBoxY;
            int width = LoadGameMenuLayout.LoadSaveListBoxWidth;
            int height = LoadGameMenuLayout.LoadSaveListBoxHeight;

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
