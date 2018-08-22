using MagicalLifeSettings.Storage;

namespace MagicalLifeGUIWindows.GUI.Save_Game_Menu
{
    public static class SaveGameMenuLayout
    {
        public static int OverwriteSaveListBoxX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteSaveListBoxX;
                }
            }
        }

        public static int OverwriteSaveListBoxY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.OverwriteSaveListBoxY;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteSaveListBoxY;
                }
            }
        }

        public static int OverwriteSaveBoxWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.OverwriteSaveBoxWidth;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteSaveBoxWidth;
                }
            }
        }

        public static int OverwriteSaveBoxHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.OverwriteSaveBoxHeight;

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
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.ItemRenderCount;

                    default:
                        return SaveGameMenuLayout1920x1080.ItemRenderCount;
                }
            }
        }

        public static int OverwriteButtonX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonX;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonX;
                }
            }
        }

        public static int OverwriteButtonY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonY;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonY;
                }
            }
        }

        public static int OverwriteButtonWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonWidth;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonWidth;
                }
            }
        }

        public static int OverwriteButtonHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonHeight;

                    default:
                        return SaveGameMenuLayout1920x1080.OverwriteButtonHeight;
                }
            }
        }

        public static int NewSaveInputBoxX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxX;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxX;
                }
            }
        }

        public static int NewSaveInputBoxY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxY;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxY;
                }
            }
        }

        public static int NewSaveInputBoxWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxWidth;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxWidth;
                }
            }
        }

        public static int NewSaveInputBoxHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxHeight;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveInputBoxHeight;
                }
            }
        }

        public static int NewSaveButtonX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonX;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonX;
                }
            }
        }

        public static int NewSaveButtonY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonY;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonY;
                }
            }
        }

        public static int NewSaveButtonWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonWidth;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonWidth;
                }
            }
        }

        public static int NewSaveButtonHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonHeight;

                    default:
                        return SaveGameMenuLayout1920x1080.NewSaveButtonHeight;
                }
            }
        }
    }
}