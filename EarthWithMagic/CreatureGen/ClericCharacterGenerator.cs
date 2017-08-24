namespace EarthWithMagic.CreatureGen
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthMagicCharacters.Classes.Cleric.Generic_Cleric;
    using EarthMagicDocumentation;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Util;

    public class ClericCharacterGenerator
    {
        /// <summary>
        /// Asks the user to choose items from a list of options until the character is created.
        /// </summary>
        /// <returns></returns>
        public ICreature Generate()
        {
            Util.WriteLine(ResourceGM.GetResource("EarthMagicDocumentation.ASCII_Art.Cleric.txt"));
            GenericCleric cleric = new GenericCleric(this.GetGender(), this.GetRace(), this.GetAlignment(), this.GetName());
            cleric.IsInParty = true;
            return cleric;
        }

        private Alignment GetAlignment()
        {
            Util.WriteLine("Lawful Good, Lawful Neutral, or Lawful Evil?");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "lawful good":
                    return Alignment.LawfulGood;

                case "lawful neutral":
                    return Alignment.LawfulNeutral;

                case "lawful evil":
                    return Alignment.LawfulEvil;

                default:
                    Util.WriteLine("Invalid alignment!");
                    return this.GetAlignment();
            }
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

        /// <summary>
        /// Returns the chosen name of the character.
        /// </summary>
        /// <returns></returns>
        private string GetName()
        {
            Util.WriteLine("What is your name?");
            return Console.ReadLine();
        }

        private Race GetRace()
        {
            Util.WriteLine("Human, Elf, Dwarf, Kender, Duergar, or Unspecified?");

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

                case "duergar":
                    return Race.Duergar;

                case "unspecified":
                    return Race.Unspecified;

                default:
                    Util.WriteLine("Invalid race!");
                    return this.GetRace();
            }
        }
    }
}
