using MagicalLifeGUIWindows.Screens;
using System.Linq;

namespace MagicalLifeGUIWindows.Input.Specialized
{
    public class LogoSkip
    {
        public LogoSkip()
        {
            KeyboardHandler.keyboardListener.KeyTyped += this.KeyboardListener_KeyTyped;
        }

        private void KeyboardListener_KeyTyped(object sender, MonoGame.Extended.Input.InputListeners.KeyboardEventArgs e)
        {
            if (!Game1.SplashDone)
            {
                if (e.Key == Microsoft.Xna.Framework.Input.Keys.Escape || e.Key == Microsoft.Xna.Framework.Input.Keys.Enter || e.Key == Microsoft.Xna.Framework.Input.Keys.Space)
                {
                    this.SkipOne();
                }
            }
        }

        private void SkipOne()
        {
            foreach (LogoScreen item in Game1.SplashScreens)
            {
                if (!item.Done())
                {
                    item.Skip();
                    break;
                }
            }
        }
    }
}
