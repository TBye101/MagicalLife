using MagicalLifeSettings.Storage;

namespace MagicalLifeGUIWindows.GUI.In_Game_GUI
{
    /// <summary>
    /// Returns the correct hardcoded values for the current screen resolution for the new world menu.
    /// </summary>
    public static class InGameGUILayout
    {
        /// <summary>
        /// The x position of the turn button.
        /// </summary>
        public static int TurnButtonX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.TurnButtonX;

                    default:
                        return InGameGUILayout1920x1080.TurnButtonX;
                }
            }
        }

        /// <summary>
        /// The y position of the turn button.
        /// </summary>
        public static int TurnButtonY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.TurnButtonY;

                    default:
                        return InGameGUILayout1920x1080.TurnButtonY;
                }
            }
        }

        /// <summary>
        /// The width of the turn button.
        /// </summary>
        public static int TurnButtonWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.TurnButtonWidth;

                    default:
                        return InGameGUILayout1920x1080.TurnButtonWidth;
                }
            }
        }

        /// <summary>
        /// The height of the turn button.
        /// </summary>
        public static int TurnButtonHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.TurnButtonHeight;

                    default:
                        return InGameGUILayout1920x1080.TurnButtonHeight;
                }
            }
        }

        /// <summary>
        /// The x position at which the in game GUI container is drawn.
        /// </summary>
        public static int ContainerX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.ContainerX;

                    default:
                        return InGameGUILayout1920x1080.ContainerX;
                }
            }
        }

        /// <summary>
        /// The y position at which the in game GUI container is drawn.
        /// </summary>
        public static int ContainerY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.ContainerY;

                    default:
                        return InGameGUILayout1920x1080.ContainerY;
                }
            }
        }

        /// <summary>
        /// The width of the in game GUI container.
        /// </summary>
        public static int ContainerWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.ContainerWidth;

                    default:
                        return InGameGUILayout1920x1080.ContainerWidth;
                }
            }
        }

        /// <summary>
        /// The height of the in game GUI container.
        /// </summary>
        public static int ContainerHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.ContainerHeight;

                    default:
                        return InGameGUILayout1920x1080.ContainerHeight;
                }
            }
        }
    }
}