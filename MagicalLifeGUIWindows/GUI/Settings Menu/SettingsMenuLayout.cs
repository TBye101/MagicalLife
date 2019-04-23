using MagicalLifeAPI.Filing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Settings_Menu
{
    public static class SettingsMenuLayout
    {
        public static int MainMenuButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SetingsMenuLayout2560x1440.MainMenuButtonY;

                    default:
                        return SettingsMenuLayout1920x1080.MainMenuButtonY;
                }
            }
        }

        public static int MasterVolumeInputBoxX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SetingsMenuLayout2560x1440.MasterVolumeInputBoxX;

                    default:
                        return SettingsMenuLayout1920x1080.MasterVolumeInputBoxX;
                }
            }

        }

        public static int MasterVolumeInputBoxY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SetingsMenuLayout2560x1440.MasterVolumeInputBoxY;

                    default:
                        return SettingsMenuLayout1920x1080.MasterVolumeInputBoxY;
                }
            }
        }

        public static int MasterVolumeInputBoxWidth
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SetingsMenuLayout2560x1440.MasterVolumeInputBoxWidth;

                    default:
                        return SettingsMenuLayout1920x1080.MasterVolumeInputBoxWidth;
                }
            }
        }
        public static int MasterVolumeInputBoxHeight
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SetingsMenuLayout2560x1440.MasterVolumeInputBoxHeight;

                    default:
                        return SettingsMenuLayout1920x1080.MasterVolumeInputBoxHeight;
                }
            }

        }

        public static int MasterVolumeLabelX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SetingsMenuLayout2560x1440.MasterVolumeLabelX;

                    default:
                        return SettingsMenuLayout1920x1080.MasterVolumeLabelX;
                }
            }
        }

        public static int MasterVolumeLabelY
        {
            get
            {
                switch ((Resolution) SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SetingsMenuLayout2560x1440.MasterVolumeLabelY;

                    default:
                        return SettingsMenuLayout1920x1080.MasterVolumeLabelY;
                }
            }
        }

        public static int MasterVolumeLabelWidth
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SetingsMenuLayout2560x1440.MasterVolumeLabelWidth;

                    default:
                        return SettingsMenuLayout1920x1080.MasterVolumeLabelWidth;
                }
            }
        }

        public static int MasterVolumeLabelHeight
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return SetingsMenuLayout2560x1440.MasterVolumeLabelHeight;

                    default:
                        return SettingsMenuLayout1920x1080.MasterVolumeLabelHeight;
                }
            }
        }
    }
}
