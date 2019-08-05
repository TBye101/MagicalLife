using MLAPI.Filing;
using MLGUIWindows.GUI.Action_Menu;
using MonoGUI.MonoGUI.Input;

namespace MLGUIWindows.Input.Specialized_Handlers
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
                if (BoundHandler.GuiWindows.Contains(ActionMenu.AMenu))
                {
                    BoundHandler.RemoveContainer(ActionMenu.AMenu);
                }
                else
                {
                    ActionMenu.Initialize();
                }
            }
        }
    }
}