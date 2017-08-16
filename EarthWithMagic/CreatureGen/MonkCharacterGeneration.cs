using EarthMagicDocumentation;
using EarthWithMagicAPI.API.Util;
using EarthWithMagicAPI.API.Creature;
using EarthMagicCharacters.Classes.Monk.Generic_Monk;
using System;
using System.Collections.Generic;
using System.Text;
using EarthWithMagic.CreatureGen;

namespace EarthMagicCharacters.Classes.Monk
{
    /// <summary>
    /// Handles generation of monk characters.
    /// </summary>
    public class MonkCharacterGeneration : ICreatureGenerator
    {
        /// <summary>
        /// Asks the user to choose items from a list of options until the character is created.
        /// </summary>
        /// <returns></returns>
        public ICreature Generate()
        {
            Util.WriteLine(ResourceGM.GetResource("EarthMagicDocumentation.ASCII_Art.Monk.txt"));
            GenericMonk monk = new GenericMonk(this.GetGender(), Race.Human, Alignment.LawfulGood, this.GetName());
            monk.IsInParty = true;
            return monk;
        }

        /// <summary>
        /// Returns the chosen name of the character.
        /// </summary>
        /// <returns></returns>
        private string GetName()
        {
            Util.WriteLine("What is your name?");
            return Console.ReadLine();
        }

        /// <summary>
        /// Returns the player's chosen gender.
        /// </summary>
        /// <returns></returns>
        private Gender GetGender()
        {
            Util.WriteLine("Male, Female, or Unspecified?");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "male":
                    return Gender.Male;
                case "female":

                    return Gender.Female;
                case "unspecified":

                    return Gender.Unspecified;
                default:
                    Util.WriteLine("Invalid input!");
                    return this.GetGender();
            }
        }
    }
}
