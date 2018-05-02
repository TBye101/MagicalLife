using MagicalLifeAPI.Filing.Logging;
using MagicalLifeGUIWindows.GUI;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Used to handle the escape key, and it's many uses.
    /// </summary>
    public class EscapeHandler
    {
        public EscapeHandler(KeyboardListener listener)
        {
            listener.KeyPressed += this.Listener_KeyPressed;
        }

        private void Listener_KeyPressed(object sender, KeyboardEventArgs e)
        {
            if (e.Key == Microsoft.Xna.Framework.Input.Keys.Escape)
            {
                this.HandleEscapeKey();
            }
        }

        private void HandleEscapeKey()
        {
            //Show main menu.
            MasterLog.DebugWriteLine("Escape key pressed");
            //MainMenu.ToggleMainMenu();
            MenuHandler.Back();
        }
    }
}