using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Dynamically calculates the experience value of a creature.
    /// </summary>
    public static class ExperienceCalculator
    {
        /// <summary>
        /// Estimates the experience value of a creature.
        /// </summary>
        /// <param name="creature"></param>
        /// <returns></returns>
        public static int Calculate(ICreature creature)
        {
            int XPValue = 0;

            XPValue += Convert.ToInt32(creature.Attributes.AC * 100);
            XPValue += Convert.ToInt32(creature.Attributes.AcidResistance * 100);
            XPValue += creature.Attributes.Charisma;
            XPValue += Convert.ToInt32(creature.Attributes.CharmResistance * 100);
            XPValue += Convert.ToInt32(creature.Attributes.ColdResistance * 100);
            XPValue += creature.Attributes.Constitution * 4;
            XPValue += creature.Attributes.Dexterity * 3;
            XPValue += creature.Attributes.Dodge * 5;
            XPValue += Convert.ToInt32(creature.Attributes.ElectricResistance * 100);
            XPValue += Convert.ToInt32(creature.Attributes.FireResistance * 100);
            XPValue += Convert.ToInt32(creature.Attributes.Health * 2);
            XPValue += creature.Attributes.Initiative;
            XPValue += Convert.ToInt32(creature.Attributes.MagicResistance * 300);
            XPValue += Convert.ToInt32(creature.Attributes.PoisonResistance * 100);
            XPValue += Convert.ToInt32(creature.Attributes.SleepResistance * 100);
            XPValue += creature.Attributes.Strength * 5;
            XPValue += creature.Attributes.ToHit * 2;
            XPValue += creature.Attributes.Wisdom * 2;
            XPValue += creature.Attributes.Intelligence * 2;

            foreach (ISpell item in creature.SpellsKnown)
            {
                XPValue += item.XPValue;
            }

            foreach (IAbility item in creature.ClassAbilities)
            {
                XPValue += item.XPValue;
            }

            return XPValue;
        }
    }
}
