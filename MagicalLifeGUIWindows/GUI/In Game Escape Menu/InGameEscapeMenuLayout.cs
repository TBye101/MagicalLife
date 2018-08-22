using MagicalLifeSettings.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.In_Game_Escape_Menu
{
    public static class InGameEscapeMenuLayout
    {
        public static int ButtonX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    default:
                        return InGameEscapeMenuLayout1920x1080.ButtonX;
                }
            }
        }

        public static int ButtonWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameEscapeMenuLayout1920x1080.ButtonWidth;

                    default:
                        return InGameEscapeMenuLayout1920x1080.ButtonWidth;
                }
            }
        }

        public static int ButtonHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameEscapeMenuLayout1920x1080.ButtonHeight;

                    default:
                        return InGameEscapeMenuLayout1920x1080.ButtonHeight;
                }
            }
        }



        public static int SaveButtonY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameEscapeMenuLayout1920x1080.SaveButtonY;

                    default:
                        return InGameEscapeMenuLayout1920x1080.SaveButtonY;
                }
            }
        }

        public static int QuitButtonY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameEscapeMenuLayout1920x1080.QuitButtonY;

                    default:
                        return InGameEscapeMenuLayout1920x1080.QuitButtonY;
                }
            }
        }

        public static int BackButtonY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameEscapeMenuLayout1920x1080.BackButtonY;

                    default:
                        return InGameEscapeMenuLayout1920x1080.BackButtonY;
                }
            }
        }
    }
}
