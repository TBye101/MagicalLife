using MagicalLifeAPI.Filing;

namespace MagicalLifeGUIWindows.GUI.Join
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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return JoinGameMenuLayout2560x1440.IPInputBoxHeight;

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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return JoinGameMenuLayout2560x1440.IPInputBoxWidth;

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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return JoinGameMenuLayout2560x1440.IPInputBoxX;

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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return JoinGameMenuLayout2560x1440.IPInputBoxY;

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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return JoinGameMenuLayout2560x1440.PortInputBoxX;

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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return JoinGameMenuLayout2560x1440.JoinButtonX;

                    default:
                        return JoinGameMenuLayout1920x1080.JoinButtonX;
                }
            }
        }
    }
}