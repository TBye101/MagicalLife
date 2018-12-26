using MagicalLifeAPI.Filing;
using System.Windows.Forms;

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
            if (!SettingsManager.UniversalSettings.Settings.GameHasRunBefore)
            {
                SettingsManager.WindowSettings.Settings.ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                SettingsManager.WindowSettings.Settings.ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;
                SettingsManager.WindowSettings.Save();
            }

            game.Graphics.PreferredBackBufferHeight = SettingsManager.WindowSettings.Settings.ScreenHeight;
            game.Graphics.PreferredBackBufferWidth = SettingsManager.WindowSettings.Settings.ScreenWidth;

            game.Graphics.ToggleFullScreen();
        }
    }
}