using MagicalLifeAPI.Filing;
using MagicalLifeGUIWindows.GUI.Action_Menu;

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
                if (BoundHandler.GUIWindows.Contains(ActionMenu.AMenu))
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