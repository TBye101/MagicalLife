using MagicalLifeGUIWindows.GUI.Host_Game_Menu.Buttons;
using MagicalLifeGUIWindows.GUI.Host_Game_Menu.Input_Boxes;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Host_Game_Menu
{
    public class HostGameMenuContainer : GUIContainer
    {
        public HostButton HostButton = new HostButton();
        public HostPortInputBox HostPortInputBox = new HostPortInputBox(false);

        public HostGameMenuContainer() : base("MenuBackground", GetDrawingBounds())
        {
            this.Controls.Add(this.HostPortInputBox);
            this.Controls.Add(this.HostButton);
        }

        private static Rectangle GetDrawingBounds()
        {
            return new Rectangle(new Point(0, 0), new Point(MagicalLifeSettings.Storage.MainWindow.Default.ScreenSize.Width, MagicalLifeSettings.Storage.MainWindow.Default.ScreenSize.Height));
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}
