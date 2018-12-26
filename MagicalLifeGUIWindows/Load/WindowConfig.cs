using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Filing;
using Microsoft.Xna.Framework;
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

            RenderInfo.FullScreenWindow = new Rectangle(new Point(0, 0), new Point(SettingsManager.WindowSettings.Settings.ScreenWidth, SettingsManager.WindowSettings.Settings.ScreenHeight));

            this.SetResolution();
            game.Graphics.ToggleFullScreen();
            game.Graphics.ApplyChanges();
        }

        private void SetResolution()
        {
            if (SettingsManager.WindowSettings.Settings.ScreenWidth == 1920 && SettingsManager.WindowSettings.Settings.ScreenHeight == 1080)
            {
                SettingsManager.WindowSettings.Settings.Resolution = 0;
            }
            if (SettingsManager.WindowSettings.Settings.ScreenWidth == 2560 && SettingsManager.WindowSettings.Settings.ScreenHeight == 1440)
            {
                SettingsManager.WindowSettings.Settings.Resolution = 1;
            }

            SettingsManager.WindowSettings.Save();
        }
    }
}