using MLAPI.Filing;
using MonoGUI.MonoGUI;

namespace MLGUIWindows.GUI.In_Game_GUI
{
    /// <summary>
    /// Returns the correct hardcoded values for the current screen resolution for the new world menu.
    /// </summary>
    public static class InGameGuiLayout
    {
        /// <summary>
        /// The x position at which the in game GUI container is drawn.
        /// </summary>
        public static int ContainerX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameGuiLayout2560X1440.ContainerX;

                    default:
                        return InGameGuiLayout1920X1080.ContainerX;
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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameGuiLayout2560X1440.ContainerY;

                    default:
                        return InGameGuiLayout1920X1080.ContainerY;
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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameGuiLayout2560X1440.ContainerWidth;

                    default:
                        return InGameGuiLayout1920X1080.ContainerWidth;
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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameGuiLayout2560X1440.ContainerHeight;

                    default:
                        return InGameGuiLayout1920X1080.ContainerHeight;
                }
            }
        }

        /// <summary>
        /// The Y position at which to render the top of every action button.
        /// </summary>
        public static int ActionButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameGuiLayout2560X1440.ActionButtonY;

                    default:
                        return InGameGuiLayout1920X1080.ActionButtonY;
                }
            }
        }

        /// <summary>
        /// The size of each action button.
        /// </summary>
        public static int ActionButtonSize
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameGuiLayout2560X1440.ActionButtonSize;

                    default:
                        return InGameGuiLayout1920X1080.ActionButtonSize;
                }
            }
        }

        /// <summary>
        /// The x position at which to render the mining action button.
        /// </summary>
        public static int MineActionButtonX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameGuiLayout2560X1440.MineActionButtonX;

                    default:
                        return InGameGuiLayout1920X1080.MineActionButtonX;
                }
            }
        }

        /// <summary>
        /// The x position at which to render the mining action button.
        /// </summary>
        public static int HoeActionButtonX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameGuiLayout2560X1440.HoeActionButtonX;

                    default:
                        return InGameGuiLayout1920X1080.HoeActionButtonX;
                }
            }
        }

        /// <summary>
        /// The x position at which to render the chop action button.
        /// </summary>
        public static int ChopActionButtonX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameGuiLayout2560X1440.ChopActionButtonX;

                    default:
                        return InGameGuiLayout1920X1080.ChopActionButtonX;
                }
            }
        }
    }
}