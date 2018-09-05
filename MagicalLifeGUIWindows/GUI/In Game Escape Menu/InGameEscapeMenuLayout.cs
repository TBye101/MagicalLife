using MagicalLifeSettings.Storage;

namespace MagicalLifeGUIWindows.GUI.In
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
                    default:
                        return InGameEscapeMenuLayout1920x1080.BackButtonY;
                }
            }
        }
    }
}