namespace MagicalLifeAPI.Filing.Settings
{
    /// <summary>
    /// Holds some settings for various properties of the main window.
    /// </summary>
    public class MainWindowSettings
    {
        public int ScreenHeight { get; set; } = 1080;
        public int ScreenWidth { get; set; } = 1920;

        /// <summary>
        /// A reference to an enum that holds various resolution sizes.
        /// </summary>
        public int Resolution { get; set; }
    }
}