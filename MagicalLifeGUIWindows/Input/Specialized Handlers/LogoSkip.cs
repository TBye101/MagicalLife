using MagicalLifeGUIWindows.Screens;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    public class LogoSkip
    {
        public LogoSkip()
        {
            KeyboardHandler.KeysPressed += this.KeyboardHandler_KeysPressed;
        }

        private void KeyboardHandler_KeysPressed(object sender, Microsoft.Xna.Framework.Input.Keys e)
        {
            if (!Game1.SplashDone)
            {
                if (e == Microsoft.Xna.Framework.Input.Keys.Escape || e == Microsoft.Xna.Framework.Input.Keys.Enter || e == Microsoft.Xna.Framework.Input.Keys.Space)
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