using MagicalLifeSettings.Storage;

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
            //if (!Universal.Default.GameHasRunBefore)
            //{
            //    //int width = Screen.PrimaryScreen.WorkingArea.Width;
            //    //int height = Screen.PrimaryScreen.WorkingArea.Height;
            //    //int width = SystemInformation.VirtualScreen.Width;
            //    //int height = SystemInformation.VirtualScreen.Height;
            //    //Size test = MainWindow.Default.ScreenSize; //= new Size(width, height);
            //}

            game.Graphics.PreferredBackBufferHeight = MainWindow.Default.ScreenSize.Height;
            game.Graphics.PreferredBackBufferWidth = MainWindow.Default.ScreenSize.Width;

            //Initialize main menu
            GUI.MainMenu.MainMenu.Initialize();

            game.Graphics.ToggleFullScreen();
        }
    }
}