using MagicalLifeAPI.Filing;
using MagicalLifeGUIWindows.GUI.Action_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    public class ActionMenuHandler
    {
        public ActionMenuHandler()
        {
            KeyboardHandler.KeysPressed += this.KeyboardHandler_KeysPressed;
        }

        private void KeyboardHandler_KeysPressed(object sender, Microsoft.Xna.Framework.Input.Keys e)
        {
            if (e == SettingsManager.Keybindings.Settings.OpenActionMenu)
            {
                ActionMenu.Initialize();
            }
        }
    }
}
