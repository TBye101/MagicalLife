using Microsoft.Xna.Framework.Graphics;
using MagicalLifeSettings.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.MainMenu
{
    /// <summary>
    /// Returns the correct hardcoded values for the current screen resolution.
    /// </summary>
    public static class MainMenuLayout
    {
        static MainMenuLayout()
        {
            switch ((Resolution)MainWindow.Default.Resolution)
            {
                case Resolution._1920x1080:
                    MainMenuFont = Game1.AssetManager.Load<SpriteFont>("MainMenuFont24x");
                    break;
                default:
                    MainMenuFont = Game1.AssetManager.Load<SpriteFont>("MainMenuFont24x");
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
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return MainMenuLayout1920x1080.ButtonX;
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
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return MainMenuLayout1920x1080.ButtonWidth;
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
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return MainMenuLayout1920x1080.ButtonHeight;
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
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return MainMenuLayout1920x1080.NewGameButtonY;
                    default:
                        return MainMenuLayout1920x1080.NewGameButtonY;
                }
            }
        }

        /// <summary>
        /// How much to offset the text by in the X direction.
        /// </summary>
        public static int NewGameButtonTextXOffset
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return MainMenuLayout1920x1080.NewGameButtonTextXOffset;
                    default:
                        return MainMenuLayout1920x1080.NewGameButtonTextXOffset;
                }
            }
        }

        /// <summary>
        /// How much to offset the text by in the Y direction.
        /// </summary>
        public static int NewGameButtonTextYOffset
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return MainMenuLayout1920x1080.NewGameButtonTextYOffset;
                    default:
                        return MainMenuLayout1920x1080.NewGameButtonTextYOffset;
                }
            }
        }
    }
}
