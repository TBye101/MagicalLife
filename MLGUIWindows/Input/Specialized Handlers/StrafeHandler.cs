using Microsoft.Xna.Framework.Input;
using MLAPI.Filing;
using MLAPI.Visual.Rendering;
using MonoGUI.MonoGUI.Input;

namespace MLGUIWindows.Input.Specialized_Handlers
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
                RenderInfo.Camera2D.HandleInput(CameraMovementState.Down);
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeLeft)
            {
                RenderInfo.Camera2D.HandleInput(CameraMovementState.Left);
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeRight)
            {
                RenderInfo.Camera2D.HandleInput(CameraMovementState.Right);
            }

            if (e == SettingsManager.Keybindings.Settings.StrafeUp)
            {
                RenderInfo.Camera2D.HandleInput(CameraMovementState.Up);
            }
        }
    }
}