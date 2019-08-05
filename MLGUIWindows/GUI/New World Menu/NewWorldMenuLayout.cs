using Microsoft.Xna.Framework;
using MLAPI.Filing;
using MLGUIWindows.GUI.New_World_Menu.Buttons;
using MLGUIWindows.GUI.New_World_Menu.Input_Boxes;
using MLGUIWindows.GUI.New_World_Menu.Labels;
using MonoGUI.MonoGUI;

namespace MLGUIWindows.GUI.New_World_Menu
{
    /// <summary>
    /// Returns the correct hard coded values for the current screen resolution for the new world menu.
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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return NewWorldMenuLayout2560X1440.WorldSizeInputBoxY;

                    default:
                        return NewWorldMenuLayout1920X1080.WorldSizeInputBoxY;
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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return NewWorldMenuLayout2560X1440.WorldSizeInputBoxHeight;

                    default:
                        return NewWorldMenuLayout1920X1080.WorldSizeInputBoxHeight;
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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return NewWorldMenuLayout2560X1440.WorldSizeInputBoxWidth;

                    default:
                        return NewWorldMenuLayout1920X1080.WorldSizeInputBoxWidth;
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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return NewWorldMenuLayout2560X1440.WorldWidthInputBoxX;

                    default:
                        return NewWorldMenuLayout1920X1080.WorldWidthInputBoxX;
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
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return NewWorldMenuLayout2560X1440.WorldLengthInputBoxX;

                    default:
                        return NewWorldMenuLayout1920X1080.WorldLengthInputBoxX;
                }
            }
        }

        /// <summary>
        /// The x position at which the <see cref="NewWorldNextButton"/> is to be displayed at.
        /// </summary>
        public static int NextButtonX
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return NewWorldMenuLayout2560X1440.NextButtonX;

                    default:
                        return NewWorldMenuLayout1920X1080.NextButtonX;
                }
            }
        }

        /// <summary>
        /// The y position at which the <see cref="LengthLabel"/> is to be displayed at.
        /// </summary>
        public static int LabelY
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return NewWorldMenuLayout2560X1440.LabelY;

                    default:
                        return NewWorldMenuLayout1920X1080.LabelY;
                }
            }
        }

        /// <summary>
        /// The y position at which the <see cref="LengthLabel"/> is to be displayed at.
        /// </summary>
        public static Rectangle GameNameInputBox
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return NewWorldMenuLayout2560X1440.GameNameInputBox;

                    default:
                        return NewWorldMenuLayout1920X1080.GameNameInputBox;
                }
            }
        }
    }
}