using DungeonsOfTheGodsAPI.DND2E.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND2E.Creatures.Character_Generation
{
    /// <summary>
    /// Rolls dice for <see cref="Abilities"/> values, and informs the player the class options availible with each set.
    /// </summary>
    public class AbilityDieRoller
    {
        /// <summary>
        /// Rolls dice for ability values.
        /// </summary>
        /// <returns></returns>
        public Abilities RollForAbilities()
        {
            Output.Writeline("Rolling for strength value");
            Attribute strength = new Attribute(Dice.Roll(3, 6, 0));
            Output.Writeline("Rolling for dexterity value");
            Attribute dexterity = new Attribute(Dice.Roll(3, 6, 0));
            Output.Writeline("Rolling for constitution value");
            Attribute constitution = new Attribute(Dice.Roll(3, 6, 0));
            Output.Writeline("Rolling for wisdom value");
            Attribute wisdom = new Attribute(Dice.Roll(3, 6, 0));
            Output.Writeline("Rolling for intelligence value");
            Attribute intelligence = new Attribute(Dice.Roll(3, 6, 0));
            Output.Writeline("Rolling for charisma value");
            Attribute charisma = new Attribute(Dice.Roll(3, 6, 0));

            return new Abilities(strength, dexterity, constitution, wisdom, intelligence, charisma);
        }
    }
}
