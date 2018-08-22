using MagicalLifeGUIWindows.GUI.Load_Game_Menu.Buttons;
using MagicalLifeGUIWindows.GUI.Load_Game_Menu.List_Boxes;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Load_Game_Menu
{
    public class LoadGameMenuContainer : GUIContainer
    {
        public SelectGameListBox SaveSelectListBox { get; private set; } = new SelectGameListBox();
        public LoadSaveButton LoadSaveButton { get; private set; } = new LoadSaveButton();

        public LoadGameMenuContainer() : base("MenuBackground", RenderingPipe.FullScreenWindow)
        {
            this.Controls.Add(this.SaveSelectListBox);
            this.Controls.Add(this.LoadSaveButton);
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}
