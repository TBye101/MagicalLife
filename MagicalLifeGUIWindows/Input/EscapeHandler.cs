using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.GUI;
using MagicalLifeGUIWindows.GUI.MainMenu;
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

            if (World.Dimensions.Count > 0)
            {
                //Ingame: Open up in game menu   
            }
            else
            {
                //Pregame:
                MenuHandler.Back();
            }

            MenuHandler.Back();
        }
    }
}