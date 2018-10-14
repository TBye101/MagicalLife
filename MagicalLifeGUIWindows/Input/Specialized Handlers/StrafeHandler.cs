using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Filing;
using MagicalLifeGUIWindows.Rendering;
using Microsoft.Xna.Framework.Input;

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
                RenderInfo.YViewOffset -= 10;
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeLeft)
            {
                RenderInfo.XViewOffset += 10;
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeRight)
            {
                RenderInfo.XViewOffset -= 10;
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeUp)
            {
                RenderInfo.YViewOffset += 10;
            }
        }
    }
}