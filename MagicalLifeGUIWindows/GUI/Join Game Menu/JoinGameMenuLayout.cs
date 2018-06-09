using MagicalLifeSettings.Storage;

namespace MagicalLifeGUIWindows.GUI.Join_Game_Menu
{
    public static class JoinGameMenuLayout
    {
        /// <summary>
        /// The height of the IP input box.
        /// </summary>
        public static int IPInputBoxHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return JoinGameMenuLayout1920x1080.IPInputBoxHeight;

                    default:
                        return JoinGameMenuLayout1920x1080.IPInputBoxHeight;
                }
            }
        }

        /// <summary>
        /// The width of the IP input box.
        /// </summary>
        public static int IPInputBoxWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return JoinGameMenuLayout1920x1080.IPInputBoxWidth;

                    default:
                        return JoinGameMenuLayout1920x1080.IPInputBoxWidth;
                }
            }
        }

        /// <summary>
        /// The x location of the IP input box.
        /// </summary>
        public static int IPInputBoxX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return JoinGameMenuLayout1920x1080.IPInputBoxX;

                    default:
                        return JoinGameMenuLayout1920x1080.IPInputBoxX;
                }
            }
        }

        /// <summary>
        /// The y location of the IP input box.
        /// </summary>
        public static int IPInputBoxY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return JoinGameMenuLayout1920x1080.IPInputBoxY;

                    default:
                        return JoinGameMenuLayout1920x1080.IPInputBoxY;
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
                        return JoinGameMenuLayout1920x1080.PortInputBoxX;

                    default:
                        return JoinGameMenuLayout1920x1080.PortInputBoxX;
                }
            }
        }

        /// <summary>
        /// The x position of the join button.
        /// </summary>
        public static int JoinButtonX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return JoinGameMenuLayout1920x1080.JoinButtonX;

                    default:
                        return JoinGameMenuLayout1920x1080.JoinButtonX;
                }
            }
        }
    }
}