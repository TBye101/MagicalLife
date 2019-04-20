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
    }
}
