using System;
using System.Collections.Generic;

namespace EarthWithMagicAPI.API.Stuff
{
    /// <summary>
    /// Used whenever the character has to read some text, or make a decision.
    /// </summary>
    public class StoryChoose
    {
        /// <summary>
        /// The choices below the text, if any.
        /// </summary>
        private List<string> Choices = new List<string>();

        /// <summary>
        /// The story text to show based on the player's choice.
        /// </summary>
        private List<StoryChoose> ProgressionOfChoices = new List<StoryChoose>();

        /// <summary>
        /// The text above the choices, if any.
        /// </summary>
        private List<string> TextAbove = new List<string>();

        public StoryChoose(List<string> textAbove)
        {
            this.TextAbove = textAbove;
        }

        /// <summary>
        /// Adds a new choice that can be chosen.
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="nextOptions"></param>
        public void AddChoice(string choice, StoryChoose nextOptions)
        {
            if (choice != null)
            {
                this.Choices.Add(choice);
                this.ProgressionOfChoices.Add(nextOptions);
            }
        }

        /// <summary>
        /// Asks the user to make a choice.
        /// </summary>
        public void Display()
        {
            Console.WriteLine(" ");

            foreach (string item in this.TextAbove)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(" ");

            int i = 0;
            int siz = this.Choices.Count;
            string choice = string.Empty;

            while (i != siz)
            {
                choice = string.Empty;
                choice += i.ToString();
                choice += ".";
                choice += " ";
                choice += this.Choices[i];
                i++;
            }

            string input = Console.ReadLine();

            int choice1 = Convert.ToInt32(input);
            this.Decided(choice1);
        }

        /// <summary>
        /// Follows the path that the user chose.
        /// </summary>
        /// <param name="decision"></param>
        private void Decided(int decision)
        {
            if (decision > this.ProgressionOfChoices.Count || decision < 1)
            {
                Console.WriteLine("Invalid choice! Try again!");
                string input = Console.ReadLine();

                int choice = Convert.ToInt32(input);
                this.Decided(choice);
            }
            else
            {
                this.ProgressionOfChoices[decision - 1].Display();
            }
        }
    }
}