using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Filing;
using Microsoft.Xna.Framework.Graphics;

namespace MagicalLifeGUIWindows.GUI.MainMenu
{
    /// <summary>
    /// Returns the correct hardcoded values for the current screen resolution.
    /// </summary>
    public static class MainMenuLayout
    {
        static MainMenuLayout()
        {
            switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
            {
                default:
                    MainMenuFont = Game1.AssetManager.Load<SpriteFont>(TextureLoader.FontMainMenuFont24x);
                    break;
            }
        }

        public static SpriteFont MainMenuFont { get; private set; }

        /// <summary>
        /// The x position at which the left part of the buttons on the main menu begin.
        /// </summary>
        public static int ButtonX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return MainMenuLayout2560x1440.ButtonX;

                    default:
                        return MainMenuLayout1920x1080.ButtonX;
                }
            }
        }

        /// <summary>
        /// How wide the buttons are.
        /// </summary>
        public static int ButtonWidth
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return MainMenuLayout2560x1440.ButtonWidth;

                    default:
                        return MainMenuLayout1920x1080.ButtonWidth;
                }
            }
        }

        /// <summary>
        /// How tall the buttons are.
        /// </summary>
        public static int ButtonHeight
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return MainMenuLayout2560x1440.ButtonHeight;

                    default:
                        return MainMenuLayout1920x1080.ButtonHeight;
                }
            }
        }

        /// <summary>
        /// The y position of the top of the new game button.
        /// </summary>
        public static int NewGameButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return MainMenuLayout2560x1440.NewGameButtonY;

                    default:
                        return MainMenuLayout1920x1080.NewGameButtonY;
                }
            }
        }

        /// <summary>
        /// The y position of the top of the host game button.
        /// </summary>
        public static int LoadGameButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return MainMenuLayout2560x1440.LoadGameButtonY;

                    default:
                        return MainMenuLayout1920x1080.LoadGameButtonY;
                }
            }
        }

        /// <summary>
        /// The y position of the top of the join game button.
        /// </summary>
        public static int JoinGameButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return MainMenuLayout2560x1440.JoinGameButtonY;

                    default:
                        return MainMenuLayout1920x1080.JoinGameButtonY;
                }
            }
        }

        /// <summary>
        /// The y position of the top of the quit button.
        /// </summary>
        public static int QuitButtonY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return MainMenuLayout2560x1440.QuitButtonY;

                    default:
                        return MainMenuLayout1920x1080.QuitButtonY;
                }
            }
        }
    }
}