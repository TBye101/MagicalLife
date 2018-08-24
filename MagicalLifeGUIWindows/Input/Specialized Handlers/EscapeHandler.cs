using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.GUI;
using MagicalLifeGUIWindows.GUI.In;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    /// <summary>
    /// Used to handle the escape key, and it's many uses.
    /// </summary>
    public class EscapeHandler
    {
        public EscapeHandler()
        {
            KeyboardHandler.keyboardListener.KeyPressed += this.Listener_KeyPressed;
        }

        private void Listener_KeyPressed(object sender, KeyboardEventArgs e)
        {
            if (e.Key == SettingsManager.Keybindings.Settings.OpenInGameEscapeMenu)
            {
                this.HandleEscapeKey();
            }
        }

        private void HandleEscapeKey()
        {
            //Show main menu.
            MasterLog.DebugWriteLine("Escape key pressed");

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