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
            game.Graphics.PreferredBackBufferHeight = MagicalLifeSettings.Storage.MainWindow.Default.ScreenSize.Height;
            game.Graphics.PreferredBackBufferWidth = MagicalLifeSettings.Storage.MainWindow.Default.ScreenSize.Width;
            game.Graphics.ToggleFullScreen();
        }
    }
}