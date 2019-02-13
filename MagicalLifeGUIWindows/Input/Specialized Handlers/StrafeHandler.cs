using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Filing;
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
                RenderInfo.Camera2D.HandleInput(Rendering.Map.CameraMovementState.Down);
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeLeft)
            {
                RenderInfo.Camera2D.HandleInput(Rendering.Map.CameraMovementState.Left);
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeRight)
            {
                RenderInfo.Camera2D.HandleInput(Rendering.Map.CameraMovementState.Right);
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeUp)
            {
                RenderInfo.Camera2D.HandleInput(Rendering.Map.CameraMovementState.Up);
            }
        }
    }
}