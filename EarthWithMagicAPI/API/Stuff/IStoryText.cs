using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Stuff
{
    /// <summary>
    /// Used whenever the character has to read some text, or make a decision.
    /// </summary>
    public class IStoryText
    {
        /// <summary>
        /// The text above the choices, if any.
        /// </summary>
        private List<string> TextAbove = new List<string>();

        /// <summary>
        /// The choices below the text, if any.
        /// </summary>
        private List<string> Choices = new List<string>();

        /// <summary>
        /// The story text to show based on the player's choice.
        /// </summary>
        private List<IStoryText> ProgressionOfChoices = new List<IStoryText>();

        public IStoryText()
        {

        }
    }
}
