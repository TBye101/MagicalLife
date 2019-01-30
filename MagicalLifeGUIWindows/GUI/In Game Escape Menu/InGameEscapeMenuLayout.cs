using MagicalLifeAPI.Filing;

namespace MagicalLifeGUIWindows.GUI.In
{
    public static class InGameEscapeMenuLayout
    {
        public static int ButtonX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameEscapeMenuLayout2560x1440.ButtonX;

                    default:
                        return InGameEscapeMenuLayout1920x1080.ButtonX;
                }
            }
        }

        public static int ButtonWidth
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameEscapeMenuLayout2560x1440.ButtonWidth;

                    default:
                        return InGameEscapeMenuLayout1920x1080.ButtonWidth;
                }
            }
        }

        public static int ButtonHeight
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameEscapeMenuLayout2560x1440.ButtonHeight;

                    default:
                        return InGameEscapeMenuLayout1920x1080.ButtonHeight;
                }
            }
        }

        public static int SaveButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameEscapeMenuLayout2560x1440.SaveButtonY;

                    default:
                        return InGameEscapeMenuLayout1920x1080.SaveButtonY;
                }
            }
        }

        public static int QuitButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameEscapeMenuLayout2560x1440.QuitButtonY;

                    default:
                        return InGameEscapeMenuLayout1920x1080.QuitButtonY;
                }
            }
        }

        public static int BackButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return InGameEscapeMenuLayout2560x1440.BackButtonY;

                    default:
                        return InGameEscapeMenuLayout1920x1080.BackButtonY;
                }
            }
        }
    }
}