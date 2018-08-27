using MagicalLifeAPI.Filing;
using MagicalLifeGUIWindows.Rendering;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    public class StrafeHandler
    {


        public StrafeHandler()
        {
            KeyboardHandler.KeysDown += this.KeyboardHandler_KeysDown;
            KeyboardHandler.KeysPressed += this.KeyboardHandler_KeysPressed;
        }

        private void KeyboardHandler_KeysPressed(object sender, Keys e)
        {

        }

        private void KeyboardHandler_KeysDown(object sender, Keys e)
        {
            if (e == SettingsManager.Keybindings.Settings.StrafeDown)
            {
                RenderingPipe.YViewOffset -= 10;
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeLeft)
            {
                RenderingPipe.XViewOffset += 10;
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeRight)
            {
                RenderingPipe.XViewOffset -= 10;
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeUp)
            {
                RenderingPipe.YViewOffset += 10;
            }
        }
    }
}
