using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.New
{
    public static class NewWorldMenuLayout2560x1440
    {
        /// <summary>
        /// The Y position at which all world size <see cref="InputBox"/>s are displayed at.
        /// </summary>
        public static readonly int WorldSizeInputBoxY = 100;

        /// <summary>
        /// The height of each world size <see cref="InputBox"/>.
        /// </summary>
        public static readonly int WorldSizeInputBoxHeight = 50;

        /// <summary>
        /// The width of each world size <see cref="InputBox"/>.
        /// </summary>
        public static readonly int WorldSizeInputBoxWidth = 100;

        /// <summary>
        /// Returns the x position of which the <see cref="WorldWidthInputBox"/> is to be displayed at.
        /// </summary>
        public static readonly int WorldWidthInputBoxX = 100;

        /// <summary>
        /// Returns the x position of which the <see cref="WorldLengthInputBox"/> is to be displayed at.
        /// </summary>
        public static readonly int WorldLengthInputBoxX = 230;

        /// <summary>
        /// The x position at which the <see cref="NewWorldNextButton"/> is to be displayed at.
        /// </summary>
        public static readonly int NextButtonX = 490;

        /// <summary>
        /// The y position at which the <see cref="LengthLabel"/> is to be displayed at.
        /// </summary>
        public static readonly int LabelY = 50;

        /// <summary>
        /// The position and size of the game name input box.
        /// </summary>
        public static readonly Rectangle GameNameInputBox = new Rectangle(360, WorldSizeInputBoxY, 100, 50);
    }
}