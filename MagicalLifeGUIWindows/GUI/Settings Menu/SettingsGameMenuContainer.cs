using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeGUIWindows.GUI.Reusable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeGUIWindows.GUI.Settings_Menu.Buttons;
using MagicalLifeGUIWindows.GUI.Settings_Menu.InputBoxes;

namespace MagicalLifeGUIWindows.GUI.Settings_Menu
{
    public class SettingsGameMenuContainer : GUIContainer
    {
        public SettingsGameMenuContainer(bool fromMainMenu) : base(TextureLoader.GUIMenuBackground, RenderInfo.FullScreenWindow, false)
        {
            this.Controls.Add(new MainMenuButton(fromMainMenu));
            this.Controls.Add(new MasterVolumeInputBox());
        }

        public override string GetTextureName()
        {
             return TextureLoader.GUIMenuBackground;
        }
    }
}
