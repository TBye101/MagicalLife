using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND2E.Creatures.Character_Generation.Character_Creation_Rules
{
    /// <summary>
    /// Used to determine all possible options for character creation in terms of druid characters from ability scores.
    /// </summary>
    public class DruidCreationCompatibility : ICharacterOptionsCompatibility
    {
        public List<CharacterOption> GetOptions(Abilities abilities)
        {
            List<CharacterOption> options = new List<CharacterOption>();
            if (this.CanBeFemaleHalfEfl(abilities))
            {
                options.Add(new CharacterOption(RaceName.HalfElven, ClassName.Druid, ClassName.None, Gender.Female));
            }
            if (this.CanBeFemaleHuman(abilities))
            {
                options.Add(new CharacterOption(RaceName.Human, ClassName.Druid, ClassName.None, Gender.Female));
            }
            if (this.CanBeMaleHalfElf(abilities))
            {
                options.Add(new CharacterOption(RaceName.HalfElven, ClassName.Druid, ClassName.None, Gender.Male));
            }
            if (this.CanBeMaleHuman(abilities))
            {
                options.Add(new CharacterOption(RaceName.Human, ClassName.Druid, ClassName.None, Gender.Male));
            }

            return options;
        }

        private bool CanBeMaleHalfElf(Abilities abilities)
        {
            bool strength = abilities.Strength.Value >= 6 && abilities.Strength.Value <= 18;
            bool intelligence = abilities.Intelligence.Value >= 6;
            bool wisdom = abilities.Wisdom.Value >= 12;
            bool dexterity = abilities.Dexterity.Value >= 6;
            bool constitution = abilities.Constitution.Value >= 6;
            bool charisma = abilities.Charisma.Value >= 15;

            return strength && intelligence && wisdom && dexterity && constitution && charisma;
        }

        private bool CanBeFemaleHalfEfl(Abilities abilities)
        {
            return this.CanBeMaleHalfElf(abilities) && abilities.Strength.Value <= 17;
        }

        private bool CanBeMaleHuman(Abilities abilities)
        {
            bool strength = abilities.Strength.Value >= 6 && abilities.Strength.Value <= 18;
            bool intelligence = abilities.Intelligence.Value >= 6;
            bool wisdom = abilities.Wisdom.Value >= 12;
            bool dexterity = abilities.Dexterity.Value >= 6;
            bool constitution = abilities.Constitution.Value >= 6;
            bool charisma = abilities.Charisma.Value >= 15;

            return strength && intelligence && wisdom && dexterity && constitution && charisma;
        }

        private bool CanBeFemaleHuman(Abilities abilities)
        {
            return this.CanBeMaleHuman(abilities);
        }
    }
}
