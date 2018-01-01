using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND2E.Creatures.Character_Generation.Character_Creation_Rules
{
    /// <summary>
    /// Used to determine if a cleric could be created from the ability score, and what races it could be.
    /// </summary>
    public class ClericCreationCompatability : ICharacterOptionsCompatibility
    {
        /// <summary>
        /// Returns all possible combinations involving a cleric that are availible to the current ability score.
        /// </summary>
        /// <returns></returns>
        public List<CharacterOption> GetOptions(Abilities abilities)
        {
            List<CharacterOption> options = new List<CharacterOption>();

            if (this.CanBeFemaleHalfElf(abilities))
            {
                options.Add(new CharacterOption(RaceName.HalfElven, ClassName.Cleric, ClassName.None, Gender.Female));
            }
            if (this.CanBeFemaleHalfOrc(abilities))
            {
                options.Add(new CharacterOption(RaceName.HalfOrc, ClassName.Cleric, ClassName.None, Gender.Female));
            }
            if (this.CanBeFemaleHuman(abilities))
            {
                options.Add(new CharacterOption(RaceName.Human, ClassName.Cleric, ClassName.None, Gender.Female));
            }
            if (this.CanBeMaleHalfElf(abilities))
            {
                options.Add(new CharacterOption(RaceName.HalfElven, ClassName.Cleric, ClassName.None, Gender.Male));
            }
            if (this.CanBeMaleHalfOrc(abilities))
            {
                options.Add(new CharacterOption(RaceName.HalfOrc, ClassName.Cleric, ClassName.None, Gender.Male));
            }
            if (this.CanBeMaleHuman(abilities))
            {
                options.Add(new CharacterOption(RaceName.Human, ClassName.Cleric, ClassName.None, Gender.Male));
            }

            return options;
        }

        /// <summary>
        /// Determines if the ability scores given could make a male half elf character.
        /// </summary>
        /// <param name="abilities"></param>
        /// <returns></returns>
        public bool CanBeMaleHalfElf(Abilities abilities)
        {
            bool strength = abilities.Strength.Value > 5 && abilities.Strength.Value <= 18.9;
            bool intelligence = abilities.Intelligence.Value >= 6;
            bool wisdom = abilities.Wisdom.Value >= 9;
            bool dexterity = abilities.Dexterity.Value >= 6;
            bool constitution = abilities.Constitution.Value >= 6;
            bool charisma = abilities.Charisma.Value >= 6;
            return strength && intelligence && wisdom && dexterity && constitution && charisma;
        }

        /// <summary>
        /// Determines if the ability scores given could make a female half elf character.
        /// </summary>
        /// <param name="abilities"></param>
        /// <returns></returns>
        public bool CanBeFemaleHalfElf(Abilities abilities)
        {
            return this.CanBeMaleHalfElf(abilities) && abilities.Strength.Value <= 17;
        }

        /// <summary>
        /// Determines if the ability scores given could make a female half orc character.
        /// </summary>
        /// <param name="abilities"></param>
        /// <returns></returns>
        public bool CanBeFemaleHalfOrc(Abilities abilities)
        {
            return this.CanBeMaleHalfOrc(abilities) && abilities.Strength.Value <= 18.75;
        }

        /// <summary>
        /// Determines if the ability scores given could make a male half orc character.
        /// </summary>
        /// <param name="abilities"></param>
        /// <returns></returns>
        public bool CanBeMaleHalfOrc(Abilities abilities)
        {
            bool strength = abilities.Strength.Value >= 6 && abilities.Strength.Value <= 18.99;
            bool intelligence = abilities.Intelligence.Value >= 6 && abilities.Intelligence.Value <= 17;
            bool wisdom = abilities.Wisdom.Value >= 6 && abilities.Wisdom.Value <= 14;
            bool dexterity = abilities.Dexterity.Value >= 5 && abilities.Dexterity.Value <= 14;
            bool constitution = abilities.Constitution.Value >= 13;
            bool charisma = abilities.Charisma.Value >= 6 && abilities.Charisma.Value <= 12;

            return strength && intelligence && wisdom && dexterity && constitution && charisma;
        }

        /// <summary>
        /// Determines if the ability scores given could make a male human character.
        /// </summary>
        /// <param name="abilities"></param>
        /// <returns></returns>
        public bool CanBeMaleHuman(Abilities abilities)
        {
            bool strength = abilities.Strength.Value >= 6;
            bool intelligence = abilities.Intelligence.Value >= 6;
            bool wisdom = abilities.Wisdom.Value >= 6;
            bool dexterity = abilities.Dexterity.Value >= 5;
            bool constitution = abilities.Constitution.Value >= 6;
            bool charisma = abilities.Charisma.Value >= 6;

            return strength && intelligence && wisdom && dexterity && constitution && charisma;
        }

        /// <summary>
        /// Determines if the ability scores given could make a female human character.
        /// </summary>
        /// <param name="abilities"></param>
        /// <returns></returns>
        public bool CanBeFemaleHuman(Abilities abilities)
        {
            return this.CanBeMaleHuman(abilities) && abilities.Strength.Value <= 18.50;
        }
    }
}
