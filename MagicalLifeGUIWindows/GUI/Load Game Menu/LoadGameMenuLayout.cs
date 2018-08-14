using MagicalLifeSettings.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Load_Game_Menu
{
    public static class LoadGameMenuLayout
    {
        public static int LoadSaveListBoxX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxX;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxX;
                }
            }
        }

        public static int LoadSaveListBoxY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxY;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxY;
                }
            }
        }

        public static int LoadSaveListBoxWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxWidth;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxWidth;
                }
            }
        }

        public static int LoadSaveListBoxHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxHeight;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveListBoxHeight;
                }
            }
        }

        public static int ItemRenderCount
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return LoadGameMenuLayout1920x1080.ItemRenderCount;

                    default:
                        return LoadGameMenuLayout1920x1080.ItemRenderCount;
                }
            }
        }








        public static int LoadSaveButtonX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonX;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonX;
                }
            }
        }

        public static int LoadSaveButtonY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonY;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonY;
                }
            }
        }

        public static int LoadSaveButtonWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonWidth;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonWidth;
                }
            }
        }

        public static int LoadSaveButtonHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonHeight;

                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonHeight;
                }
            }
        }
    }
}
