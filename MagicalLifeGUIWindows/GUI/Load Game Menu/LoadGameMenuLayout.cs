using MagicalLifeAPI.Filing;

namespace MagicalLifeGUIWindows.GUI.Load
{
    public static class LoadGameMenuLayout
    {
        public static int LoadSaveListBoxX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return LoadGameMenuLayout2560x1440.LoadSaveListBoxX;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxX;
                }
            }
        }

        public static int LoadSaveListBoxY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return LoadGameMenuLayout2560x1440.LoadSaveListBoxY;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxY;
                }
            }
        }

        public static int LoadSaveListBoxWidth
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return LoadGameMenuLayout2560x1440.LoadSaveListBoxWidth;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxWidth;
                }
            }
        }

        public static int LoadSaveListBoxHeight
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return LoadGameMenuLayout2560x1440.LoadSaveListBoxHeight;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxHeight;
                }
            }
        }

        public static int ItemRenderCount
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return LoadGameMenuLayout2560x1440.ItemRenderCount;

                    default:
                        return LoadGameMenuLayout1920x1080.ItemRenderCount;
                }
            }
        }

        public static int LoadSaveButtonX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return LoadGameMenuLayout2560x1440.LoadSaveButtonX;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonX;
                }
            }
        }

        public static int LoadSaveButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return LoadGameMenuLayout2560x1440.LoadSaveButtonY;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonY;
                }
            }
        }

        public static int LoadSaveButtonWidth
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return LoadGameMenuLayout2560x1440.LoadSaveButtonWidth;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonWidth;
                }
            }
        }

        public static int LoadSaveButtonHeight
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return LoadGameMenuLayout2560x1440.LoadSaveButtonHeight;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonHeight;
                }
            }
        }
    }
}