using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Filing.Settings
{
    /// <summary>
    /// Holds some settings for various properties of the main window.
    /// </summary>
    public class MainWindowSettings
    {
        public int ScreenHeight { get; set; }
        public int ScreenWidth { get; set; }

        /// <summary>
        /// A reference to an enum that holds various resolution sizes.
        /// </summary>
        public int Resolution { get; set; }
    }
}
