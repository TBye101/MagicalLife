// <copyright file="ExperienceCalculator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Creature
{
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using System;

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
            int xPValue = 0;

            xPValue += Convert.ToInt32(creature.Attributes.BaseAC * 100);
            xPValue += Convert.ToInt32(creature.Attributes.BaseAcidResistance * 100);
            xPValue += creature.Attributes.BaseCharisma;
            xPValue += Convert.ToInt32(creature.Attributes.BaseCharmResistance * 100);
            xPValue += Convert.ToInt32(creature.Attributes.BaseColdResistance * 100);
            xPValue += creature.Attributes.BaseConstitution * 4;
            xPValue += creature.Attributes.BaseDexterity * 3;
            xPValue += Convert.ToInt32(creature.Attributes.BaseDodge * 5);
            xPValue += Convert.ToInt32(creature.Attributes.BaseElectricResistance * 100);
            xPValue += Convert.ToInt32(creature.Attributes.BaseFireResistance * 100);
            xPValue += Convert.ToInt32(creature.Attributes.BaseHealth * 2);
            xPValue += creature.Attributes.BaseInitiative;
            xPValue += Convert.ToInt32(creature.Attributes.BaseMagicResistance * 300);
            xPValue += Convert.ToInt32(creature.Attributes.BasePoisonResistance * 100);
            xPValue += Convert.ToInt32(creature.Attributes.BaseSleepResistance * 100);
            xPValue += creature.Attributes.BaseStrength * 5;
            xPValue += Convert.ToInt32(creature.Attributes.BaseToHit * 200);
            xPValue += creature.Attributes.BaseWisdom * 2;
            xPValue += creature.Attributes.BaseIntelligence * 2;

            foreach (ISpell item in creature.SpellsKnown)
            {
                xPValue += item.XPValue;
            }

            foreach (IAbility item in creature.ClassAbilities)
            {
                xPValue += item.XPValue;
            }

            return xPValue;
        }
    }
}