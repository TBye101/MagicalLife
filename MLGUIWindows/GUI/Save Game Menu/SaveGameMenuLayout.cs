using MLAPI.Filing;
using MonoGUI.MonoGUI;

namespace MLGUIWindows.GUI.Save_Game_Menu
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
                        return SaveGameMenuLayout2560X1440.OverwriteSaveListBoxX;

                    default:
                        return SaveGameMenuLayout1920X1080.OverwriteSaveListBoxX;
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
                        return SaveGameMenuLayout2560X1440.OverwriteSaveListBoxY;

                    default:
                        return SaveGameMenuLayout1920X1080.OverwriteSaveListBoxY;
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
                        return SaveGameMenuLayout2560X1440.OverwriteSaveBoxWidth;

                    default:
                        return SaveGameMenuLayout1920X1080.OverwriteSaveBoxWidth;
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
                        return SaveGameMenuLayout2560X1440.OverwriteSaveBoxHeight;

                    default:
                        return SaveGameMenuLayout1920X1080.OverwriteSaveBoxHeight;
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
                        return SaveGameMenuLayout2560X1440.ItemRenderCount;

                    default:
                        return SaveGameMenuLayout1920X1080.ItemRenderCount;
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
                        return SaveGameMenuLayout2560X1440.OverwriteButtonX;

                    default:
                        return SaveGameMenuLayout1920X1080.OverwriteButtonX;
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
                        return SaveGameMenuLayout2560X1440.OverwriteButtonY;

                    default:
                        return SaveGameMenuLayout1920X1080.OverwriteButtonY;
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
                        return SaveGameMenuLayout2560X1440.OverwriteButtonWidth;

                    default:
                        return SaveGameMenuLayout1920X1080.OverwriteButtonWidth;
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
                        return SaveGameMenuLayout2560X1440.OverwriteButtonHeight;

                    default:
                        return SaveGameMenuLayout1920X1080.OverwriteButtonHeight;
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
                        return SaveGameMenuLayout2560X1440.NewSaveInputBoxX;

                    default:
                        return SaveGameMenuLayout1920X1080.NewSaveInputBoxX;
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
                        return SaveGameMenuLayout2560X1440.NewSaveInputBoxY;

                    default:
                        return SaveGameMenuLayout1920X1080.NewSaveInputBoxY;
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
                        return SaveGameMenuLayout2560X1440.NewSaveInputBoxWidth;

                    default:
                        return SaveGameMenuLayout1920X1080.NewSaveInputBoxWidth;
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
                        return SaveGameMenuLayout2560X1440.NewSaveInputBoxHeight;

                    default:
                        return SaveGameMenuLayout1920X1080.NewSaveInputBoxHeight;
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
                        return SaveGameMenuLayout2560X1440.NewSaveButtonX;

                    default:
                        return SaveGameMenuLayout1920X1080.NewSaveButtonX;
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
                        return SaveGameMenuLayout2560X1440.NewSaveButtonY;

                    default:
                        return SaveGameMenuLayout1920X1080.NewSaveButtonY;
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
                        return SaveGameMenuLayout2560X1440.NewSaveButtonWidth;

                    default:
                        return SaveGameMenuLayout1920X1080.NewSaveButtonWidth;
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
                        return SaveGameMenuLayout2560X1440.NewSaveButtonHeight;

                    default:
                        return SaveGameMenuLayout1920X1080.NewSaveButtonHeight;
                }
            }
        }
    }
}