using MLAPI.Filing;
using MonoGUI.MonoGUI;

namespace MLGUIWindows.GUI.Load_Game_Menu
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
                        return LoadGameMenuLayout2560X1440.LoadSaveListBoxX;

                    default:
                        return LoadGameMenuLayout1920X1080.LoadSaveListBoxX;
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
                        return LoadGameMenuLayout2560X1440.LoadSaveListBoxY;

                    default:
                        return LoadGameMenuLayout1920X1080.LoadSaveListBoxY;
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
                        return LoadGameMenuLayout2560X1440.LoadSaveListBoxWidth;

                    default:
                        return LoadGameMenuLayout1920X1080.LoadSaveListBoxWidth;
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
                        return LoadGameMenuLayout2560X1440.LoadSaveListBoxHeight;

                    default:
                        return LoadGameMenuLayout1920X1080.LoadSaveListBoxHeight;
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
                        return LoadGameMenuLayout2560X1440.ItemRenderCount;

                    default:
                        return LoadGameMenuLayout1920X1080.ItemRenderCount;
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
                        return LoadGameMenuLayout2560X1440.LoadSaveButtonX;

                    default:
                        return LoadGameMenuLayout1920X1080.LoadSaveButtonX;
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
                        return LoadGameMenuLayout2560X1440.LoadSaveButtonY;

                    default:
                        return LoadGameMenuLayout1920X1080.LoadSaveButtonY;
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
                        return LoadGameMenuLayout2560X1440.LoadSaveButtonWidth;

                    default:
                        return LoadGameMenuLayout1920X1080.LoadSaveButtonWidth;
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
                        return LoadGameMenuLayout2560X1440.LoadSaveButtonHeight;

                    default:
                        return LoadGameMenuLayout1920X1080.LoadSaveButtonHeight;
                }
            }
        }
    }
}