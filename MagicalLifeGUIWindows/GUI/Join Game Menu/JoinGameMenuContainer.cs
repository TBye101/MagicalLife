using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Join_Game_Menu
{
    class JoinGameMenuContainer : GUIContainer
    {
        public JoinGameMenuContainer() : base("MenuBackground", RenderingPipe.FullScreenWindow)
        {
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}
