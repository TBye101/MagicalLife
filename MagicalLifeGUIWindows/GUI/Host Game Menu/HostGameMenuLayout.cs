using MagicalLifeSettings.Storage;

namespace MagicalLifeGUIWindows.GUI.Host_Game_Menu
{
    /// <summary>
    /// Returns the correct hard coded values for the current screen resolution for the host game menu.
    /// </summary>
    public static class HostGameMenuLayout
    {
        /// <summary>
        /// The height of all input boxes on this form.
        /// </summary>
        public static int InputBoxHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return HostGameMenuLayout1920x1080.InputBoxHeight;

                    default:
                        return HostGameMenuLayout1920x1080.InputBoxHeight;
                }
            }
        }

        /// <summary>
        /// The width of all input boxes on this form.
        /// </summary>
        public static int InputBoxWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return HostGameMenuLayout1920x1080.InputBoxWidth;

                    default:
                        return HostGameMenuLayout1920x1080.InputBoxWidth;
                }
            }
        }

        /// <summary>
        /// The x position of the port input box.
        /// </summary>
        public static int PortInputBoxX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return HostGameMenuLayout1920x1080.PortInputBoxX;

                    default:
                        return HostGameMenuLayout1920x1080.PortInputBoxX;
                }
            }
        }

        /// <summary>
        /// The x position of the port input box.
        /// </summary>
        public static int PortInputBoxY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return HostGameMenuLayout1920x1080.PortInputBoxY;

                    default:
                        return HostGameMenuLayout1920x1080.PortInputBoxY;
                }
            }
        }

        /// <summary>
        /// The x location of the host game button.
        /// </summary>
        public static int HostGameButtonX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return HostGameMenuLayout1920x1080.HostGameButtonX;

                    default:
                        return HostGameMenuLayout1920x1080.HostGameButtonX;
                }
            }
        }
    }
}