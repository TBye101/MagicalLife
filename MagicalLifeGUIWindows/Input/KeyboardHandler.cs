using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Handles keyboard input.
    /// </summary>
    public static class KeyboardHandler
    {
        public static KeyboardListener keyboardListener;

        public static void Initialize()
        {
            keyboardListener = new KeyboardListener();
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