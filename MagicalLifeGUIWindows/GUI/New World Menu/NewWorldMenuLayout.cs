using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeSettings.Storage;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu
{
    /// <summary>
    /// Returns the correct hardcoded values for the current screen resolution for the new world menu.
    /// </summary>
    public static class NewWorldMenuLayout
    {
        /// <summary>
        /// The Y position at which all world size <see cref="InputBox"/>s are displayed at.
        /// </summary>
        public static int WorldSizeInputBoxY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return NewWorldMenuLayout1920x1080.WorldSizeInputBoxY;
                    default:
                        return NewWorldMenuLayout1920x1080.WorldSizeInputBoxY;
                }
            }
        }

        /// <summary>
        /// The height of each world size <see cref="InputBox"/>. 
        /// </summary>
        public static int WorldSizeInputBoxHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return NewWorldMenuLayout1920x1080.WorldSizeInputBoxHeight;
                    default:
                        return NewWorldMenuLayout1920x1080.WorldSizeInputBoxHeight;
                }
            }
        }

        /// <summary>
        /// The width of each world size <see cref="InputBox"/>.
        /// </summary>
        public static int WorldSizeInputBoxWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return NewWorldMenuLayout1920x1080.WorldSizeInputBoxWidth;
                    default:
                        return NewWorldMenuLayout1920x1080.WorldSizeInputBoxWidth;
                }
            }
        }


        /// <summary>
        /// Returns the x position of which the <see cref="WorldWidthInputBox"/> is to be displayed at.
        /// </summary>
        public static int WorldWidthInputBoxX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return NewWorldMenuLayout1920x1080.WorldWidthInputBoxX;
                    default:
                        return NewWorldMenuLayout1920x1080.WorldWidthInputBoxX;
                }
            }
        }

        /// <summary>
        /// Returns the x position of which the <see cref="WorldLengthInputBox"/> is to be displayed at.
        /// </summary>
        public static int WorldLengthInputBoxX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return NewWorldMenuLayout1920x1080.WorldLengthInputBoxX;
                    default:
                        return NewWorldMenuLayout1920x1080.WorldLengthInputBoxX;
                }
            }
        }

        /// <summary>
        /// Returns the x position of which the <see cref="WorldDepthInputBox"/> is to be displayed at.
        /// </summary>
        public static int WorldDepthInputBoxX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return NewWorldMenuLayout1920x1080.WorldDepthInputBoxX;
                    default:
                        return NewWorldMenuLayout1920x1080.WorldDepthInputBoxX;
                }
            }
        }
    }
}
