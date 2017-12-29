using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND2E.Creatures.Character_Generation.Character_Creation_Rules
{
    /// <summary>
    /// Used to determine if a cleric could be created from the ability score, and what races it could be.
    /// </summary>
    public class ClericCreationCompatability
    {
        /// <summary>
        /// Returns all possible combinations involving a cleric that are availible to the current ability score.
        /// </summary>
        /// <returns></returns>
        public List<CharacterOption> GetClericOptions(Abilities abilities)
        {
            List<CharacterOption> options = new List<CharacterOption>();

            if (this.CanBeMaleDwarf(abilities))
            {
                options.Add(new CharacterOption(RaceName.Dwarven, ClassName.Cleric, ClassName.None, Gender.Male));
            }

            return options;
        }

        /// <summary>
        /// Determines if this character could be a dwarven cleric.
        /// </summary>
        /// <returns></returns>
        private bool CanBeMaleDwarf(Abilities abilities)
        {
            bool strengthCompatible = abilities.Strength.Value >= 8 && abilities.Strength.Value <= 18.99;
            bool intelligenceCompatible = abilities.Intelligence.Value >= 6;
            bool wisdomCompatible = abilities.Wisdom.Value >= 9;
            bool dexterityCompatible = abilities.Dexterity.Value >= 5 && abilities.Dexterity.Value <= 17;
            bool constitutionCompatible = abilities.Dexterity.Value >= 12;
            bool charismaCompatible = abilities.Charisma.Value <= 16 && abilities.Charisma.Value >= 6;

            return strengthCompatible && intelligenceCompatible && wisdomCompatible && dexterityCompatible && constitutionCompatible && charismaCompatible;
        }
    }
}
