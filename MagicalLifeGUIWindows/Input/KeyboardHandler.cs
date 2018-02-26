using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Handles keyboard input.
    /// </summary>
    public static class KeyboardHandler
    {
        public static KeyboardListener keyboardListener;

        private static EscapeHandler escapeHandler;

        public static void Initialize()
        {
            keyboardListener = new KeyboardListener();

            escapeHandler = new EscapeHandler(keyboardListener);
        }

        /// <summary>
        /// Handles keyboard input.
        /// </summary>
        /// <param name="clickData"></param>
        /// <param name="time"></param>
        public static void UpdateKeyboardInput(GameTime time)
        {
            keyboardListener.Update(time);
        }
    }
}
