using MagicalLifeAPI.Filing;

namespace MagicalLifeGUIWindows.GUI.Save
{
    public static class SaveGameMenuLayout
    {
        public static int OverwriteSaveListBoxX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.OverwriteSaveListBoxX;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteSaveListBoxX;
                }
            }
        }

        public static int OverwriteSaveListBoxY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.OverwriteSaveListBoxY;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteSaveListBoxY;
                }
            }
        }

        public static int OverwriteSaveBoxWidth
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.OverwriteSaveBoxWidth;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteSaveBoxWidth;
                }
            }
        }

        public static int OverwriteSaveBoxHeight
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.OverwriteSaveBoxHeight;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteSaveBoxHeight;
                }
            }
        }

        /// <summary>
        /// How many items to render within the list box at any given time.
        /// </summary>
        public static int ItemRenderCount
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.ItemRenderCount;

                    default:
                        return SaveGameMenuLayout1920x1080.ItemRenderCount;
                }
            }
        }

        public static int OverwriteButtonX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.OverwriteButtonX;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonX;
                }
            }
        }

        public static int OverwriteButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.OverwriteButtonY;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonY;
                }
            }
        }

        public static int OverwriteButtonWidth
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.OverwriteButtonWidth;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonWidth;
                }
            }
        }

        public static int OverwriteButtonHeight
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.OverwriteButtonHeight;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonHeight;
                }
            }
        }

        public static int NewSaveInputBoxX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.NewSaveInputBoxX;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxX;
                }
            }
        }

        public static int NewSaveInputBoxY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.NewSaveInputBoxY;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxY;
                }
            }
        }

        public static int NewSaveInputBoxWidth
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.NewSaveInputBoxWidth;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxWidth;
                }
            }
        }

        public static int NewSaveInputBoxHeight
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.NewSaveInputBoxHeight;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxHeight;
                }
            }
        }

        public static int NewSaveButtonX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.NewSaveButtonX;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonX;
                }
            }
        }

        public static int NewSaveButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.NewSaveButtonY;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonY;
                }
            }
        }

        public static int NewSaveButtonWidth
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.NewSaveButtonWidth;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonWidth;
                }
            }
        }

        public static int NewSaveButtonHeight
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SaveGameMenuLayout2560x1440.NewSaveButtonHeight;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonHeight;
                }
            }
        }
    }
}