namespace EarthWithMagicAPI.API.Creature
{
    using System;
    using EarthWithMagicAPI.API.Interfaces.Spells;

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

            XPValue += Convert.ToInt32(creature.Attributes.BaseAC * 100);
            XPValue += Convert.ToInt32(creature.Attributes.BaseAcidResistance * 100);
            XPValue += creature.Attributes.BaseCharisma;
            XPValue += Convert.ToInt32(creature.Attributes.BaseCharmResistance * 100);
            XPValue += Convert.ToInt32(creature.Attributes.BaseColdResistance * 100);
            XPValue += creature.Attributes.BaseConstitution * 4;
            XPValue += creature.Attributes.BaseDexterity * 3;
            XPValue += Convert.ToInt32(creature.Attributes.BaseDodge * 5);
            XPValue += Convert.ToInt32(creature.Attributes.BaseElectricResistance * 100);
            XPValue += Convert.ToInt32(creature.Attributes.BaseFireResistance * 100);
            XPValue += Convert.ToInt32(creature.Attributes.BaseHealth * 2);
            XPValue += creature.Attributes.BaseInitiative;
            XPValue += Convert.ToInt32(creature.Attributes.BaseMagicResistance * 300);
            XPValue += Convert.ToInt32(creature.Attributes.BasePoisonResistance * 100);
            XPValue += Convert.ToInt32(creature.Attributes.BaseSleepResistance * 100);
            XPValue += creature.Attributes.BaseStrength * 5;
            XPValue += Convert.ToInt32(creature.Attributes.BaseToHit * 200);
            XPValue += creature.Attributes.BaseWisdom * 2;
            XPValue += creature.Attributes.BaseIntelligence * 2;

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