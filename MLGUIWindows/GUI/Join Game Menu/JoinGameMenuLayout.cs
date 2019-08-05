using MLAPI.Filing;
using MonoGUI.MonoGUI;

namespace MLGUIWindows.GUI.Join_Game_Menu
{
    public static class JoinGameMenuLayout
    {
        /// <summary>
        /// The height of the IP input box.
        /// </summary>
        public static int IpInputBoxHeight
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return JoinGameMenuLayout2560X1440.IpInputBoxHeight;

                    default:
                        return JoinGameMenuLayout1920X1080.IpInputBoxHeight;
                }
            }
        }

        /// <summary>
        /// The width of the IP input box.
        /// </summary>
        public static int IpInputBoxWidth
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return JoinGameMenuLayout2560X1440.IpInputBoxWidth;

                    default:
                        return JoinGameMenuLayout1920X1080.IpInputBoxWidth;
                }
            }
        }

        /// <summary>
        /// The x location of the IP input box.
        /// </summary>
        public static int IpInputBoxX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return JoinGameMenuLayout2560X1440.IpInputBoxX;

                    default:
                        return JoinGameMenuLayout1920X1080.IpInputBoxX;
                }
            }
        }

        /// <summary>
        /// The y location of the IP input box.
        /// </summary>
        public static int IpInputBoxY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return JoinGameMenuLayout2560X1440.IpInputBoxY;

                    default:
                        return JoinGameMenuLayout1920X1080.IpInputBoxY;
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
                        return JoinGameMenuLayout2560X1440.PortInputBoxX;

                    default:
                        return JoinGameMenuLayout1920X1080.PortInputBoxX;
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
                        return JoinGameMenuLayout2560X1440.JoinButtonX;

                    default:
                        return JoinGameMenuLayout1920X1080.JoinButtonX;
                }
            }
        }
    }
}