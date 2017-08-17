using EarthMagicCharacters.Classes.Thief.Generic_Thief;
using EarthMagicDocumentation;
using EarthWithMagicAPI.API.Creature;
using EarthWithMagicAPI.API.Util;
using System;

namespace EarthWithMagic.CreatureGen
{
    internal class ThiefCharacterGenerator : ICreatureGenerator
    {
        /// <summary>
        /// Asks the user to choose items from a list of options until the character is created.
        /// </summary>
        /// <returns></returns>
        public ICreature Generate()
        {
            Util.WriteLine(ResourceGM.GetResource("EarthMagicDocumentation.ASCII_Art.Thief.txt"));
            GenericThief monk = new GenericThief(this.GetGender(), this.GetRace(), this.GetAlignment(), this.GetName());
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

        private Race GetRace()
        {
            Util.WriteLine("Human, Elf, Dwarf, Kender, Drow, Dragonborn, or Unspecified?");

            string Input = Console.ReadLine();

            switch (Input.ToLower())
            {
                case "human":
                    return Race.Human;

                case "elf":
                    return Race.Elf;

                case "dwarf":
                    return Race.Dwarf;

                case "kender":
                    return Race.Kender;

                case "dragonborn":
                    return Race.Dragonborn;

                case "unspecified":
                    return Race.Unspecified;

                default:
                    Util.WriteLine("Invalid race!");
                    return this.GetRace();
            }
        }

        private Alignment GetAlignment()
        {
            Util.WriteLine("Lawful Good, Chaotic Good, Lawful Neutral, True Neutral, Chaotic Neutral, Lawful Evil, Neutral Evil, or Chaotic Evil?");
            string Input = Console.ReadLine();

            switch (Input.ToLower())
            {
                case "lawful good":
                    return Alignment.LawfulGood;

                case "chaotic good":
                    return Alignment.ChaoticGood;

                case "lawful neutral":
                    return Alignment.LawfulNeutral;

                case "true neutral":
                    return Alignment.TrueNeutral;

                case "chaotic neutral":
                    return Alignment.ChaoticNeutral;

                case "lawful evil":
                    return Alignment.LawfulEvil;

                case "neutral evil":
                    return Alignment.NeutralEvil;

                case "chaotic evil":
                    return Alignment.ChaoticEvil;

                default:
                    Util.WriteLine("Invalid alignment!");
                    return this.GetAlignment();
            }
        }
    }
}