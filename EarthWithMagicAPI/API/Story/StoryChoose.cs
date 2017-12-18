// <copyright file="StoryChoose.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Stuff
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Used whenever the character has to read some text, or make a decision.
    /// </summary>
    public abstract class StoryChoose
    {
        /// <summary>
        /// The choices below the text, if any.
        /// </summary>
        private List<string> choices = new List<string>();

        /// <summary>
        /// The story text to show based on the player's choice.
        /// </summary>
        private List<StoryChoose> progressionOfChoices = new List<StoryChoose>();

        /// <summary>
        /// The text above the choices, if any.
        /// </summary>
        private List<string> textAbove = new List<string>();

        public StoryChoose(List<string> textAbove)
        {
            this.textAbove = textAbove;
        }

        /// <summary>
        /// This method is called when this story choice is chosen or displayed.
        /// </summary>
        public abstract void OnChosen();

        /// <summary>
        /// Adds a new choice that can be chosen.
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="nextOptions"></param>
        public void AddChoice(string choice, StoryChoose nextOptions)
        {
            if (choice != null)
            {
                this.choices.Add(choice);
                this.progressionOfChoices.Add(nextOptions);
            }
        }

        /// <summary>
        /// Asks the user to make a choice.
        /// </summary>
        public void Display()
        {
            Filing.Writeline(" ");

            foreach (string item in this.textAbove)
            {
                Filing.Writeline(item);
            }

            Filing.Writeline(" ");

            int i = 0;
            int siz = this.choices.Count;
            string choice = string.Empty;

            while (i != siz)
            {
                choice = string.Empty;
                choice += i.ToString();
                choice += ".";
                choice += " ";
                choice += this.choices[i];
                i++;
            }

            string input = Filing.Readline();

            int choice1 = Convert.ToInt32(input);
            this.Decided(choice1);
        }

        /// <summary>
        /// Follows the path that the user chose.
        /// </summary>
        /// <param name="decision"></param>
        private void Decided(int decision)
        {
            if (decision > this.progressionOfChoices.Count || decision < 1)
            {
                Filing.Writeline("Invalid choice! Try again!");
                string input = Filing.Readline();

                int choice = Convert.ToInt32(input);
                this.Decided(choice);
            }
            else
            {
                this.progressionOfChoices[decision - 1].Display();
            }
        }
    }
}