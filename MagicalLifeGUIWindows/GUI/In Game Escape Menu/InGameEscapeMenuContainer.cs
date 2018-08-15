using MagicalLifeGUIWindows.GUI.In_Game_Escape_Menu.Buttons;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.In_Game_Escape_Menu
{
    public class InGameEscapeMenuContainer : GUIContainer
    {
        public QuitButton Quit = new QuitButton();

        public SaveButton Save = new SaveButton();

        public InGameEscapeMenuContainer() : base("MenuBackground", RenderingPipe.FullScreenWindow)
        {
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.Save);
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}
