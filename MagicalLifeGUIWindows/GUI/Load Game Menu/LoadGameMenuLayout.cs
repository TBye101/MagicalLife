using MagicalLifeSettings.Storage;

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
                    default:
                        return LoadGameMenuLayout1920x1080.LoadSaveButtonHeight;
                }
            }
        }
    }
}