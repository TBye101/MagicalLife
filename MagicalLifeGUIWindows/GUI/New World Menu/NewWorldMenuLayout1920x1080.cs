using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeGUIWindows.GUI.New_World_Menu.Input_Boxes;
using MagicalLifeGUIWindows.GUI.New_World_Menu.Buttons;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu
{
    public class NewWorldMenuLayout1920x1080
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
        /// Returns the x position of which the <see cref="WorldDepthInputBox"/> is to be displayed at.
        /// </summary>
        public static readonly int WorldDepthInputBoxX = 360;

        /// <summary>
        /// The x position at which the <see cref="NewWorldNextButton"/> is to be displayed at.
        /// </summary>
        public static readonly int NextButtonX = 530;
    }
}
