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
            KeyboardHandler.keyboardListener.KeyTyped += this.KeyboardListener_KeyTyped;
            KeyboardHandler.keyboardListener.KeyPressed += this.KeyboardListener_KeyPressed;
            
        }

        private void KeyboardListener_KeyPressed(object sender, MonoGame.Extended.Input.InputListeners.KeyboardEventArgs e)
        {
            if (e.Key == SettingsManager.Keybindings.Settings.StrafeDown)
            {
                RenderingPipe.YViewOffset += 10;
            }

            if (e.Key == SettingsManager.Keybindings.Settings.StrafeLeft)
            {
                RenderingPipe.XViewOffset -= 10;
            }

            if (e.Key == SettingsManager.Keybindings.Settings.StrafeRight)
            {
                RenderingPipe.XViewOffset += 10;
            }

            if (e.Key == SettingsManager.Keybindings.Settings.StrafeUp)
            {
                RenderingPipe.YViewOffset -= 10;
            }
        }

        private void KeyboardListener_KeyTyped(object sender, MonoGame.Extended.Input.InputListeners.KeyboardEventArgs e)
        {

        }
    }
}
