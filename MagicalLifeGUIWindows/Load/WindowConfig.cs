using MagicalLifeAPI.Filing;

namespace MagicalLifeGUIWindows.Load
{
    /// <summary>
    /// Handles configuring the main window.
    /// </summary>
    public class WindowConfig
    {
        /// <summary>
        /// Configures the main window.
        /// </summary>
        /// <param name="game"></param>
        public void ConfigureMainWindow(Game1 game)
        {
            game.Graphics.PreferredBackBufferHeight = SettingsManager.WindowSettings.Settings.ScreenHeight;
            game.Graphics.PreferredBackBufferWidth = SettingsManager.WindowSettings.Settings.ScreenWidth;

            game.Graphics.ToggleFullScreen();
        }
    }
}