using MLAPI.Filing;
using MLAPI.Filing.Logging;
using MLAPI.World.Data;
using MLGUIWindows.GUI.Action_Menu;
using MLGUIWindows.GUI.In_Game_Escape_Menu;
using MonoGUI.MonoGUI;
using MonoGUI.MonoGUI.Input;

namespace MLGUIWindows.Input.Specialized_Handlers
{
    /// <summary>
    /// Used to handle the escape key, and it's many uses.
    /// </summary>
    public class EscapeHandler
    {
        public EscapeHandler()
        {
            KeyboardHandler.KeysPressed += this.KeyboardHandler_KeysPressed;
        }

        private void KeyboardHandler_KeysPressed(object sender, Microsoft.Xna.Framework.Input.Keys e)
        {
            if (e == SettingsManager.Keybindings.Settings.OpenInGameEscapeMenu)
            {
                this.HandleEscapeKey();
            }
        }

        private void HandleEscapeKey()
        {
            //Show main menu.
            MasterLog.DebugWriteLine("Escape key pressed");

            if (ActionMenu.AMenu.Visible == true)
            {
                BoundHandler.RemoveContainer(ActionMenu.AMenu);
            }

            if (World.Dimensions.Count > 0)
            {
                //Ingame: Open up in game menu
                InGameEscapeMenu.Initialize();
            }
            else
            {
                //Pregame:
                MenuHandler.Back();
            }
        }
    }
}