namespace EarthMagicCharacters.Classes.Wizard.Generic_Wizard
{
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Stuff;
    using EarthWithMagicAPI.API.Util;
    using System;

    /// <summary>
    /// The base wizard class.
    /// </summary>
    public class GenericWizard : ICharacter
    {
        public GenericWizard(Gender gender, Race race, Alignment alignment, string name = "Wizard", bool isHostile = false)
            : base(GetAtt(gender, race, alignment), new CreatureAbilities(), "EarthMagicDocumentation.Classes.Wizard_Class_Info.md", "EarthMagicDocumentation.ASCII_Art.Wizard.txt")
        {
            this.MaxCastingPower += 5;
        }

        /// <summary>
        /// Called whenever the creature has a new item equipped.
        /// </summary>
        /// <param name="item"></param>
        public override void EquipItem(IItem item)
        {
        }

        public override bool IsHostile()
        {
            return !this.IsInParty;
        }

        public override void LevelUp()
        {
#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis

            this.Attributes.BaseHealth += Dice.RollDice(new Die(1, 4, 1), this.Name + " gains hit points: ");
            int castingPower = this.MaxCastingPower;
            switch (this.Attributes.XP.CreatureLevel)
            {
                case int n when (n >= 1 && n <= 4):
                    this.MaxCastingPower++;
                    break;
                case int n when (n >= 5 && n <= 8):
                    this.MaxCastingPower += 2;
                    break;
                case int n when (n >= 9 && n <= 13):
                    this.MaxCastingPower += 3;
                    break;
                case int n when (n >= 14 && n <= 18):
                    this.MaxCastingPower += 4;
                    break;
                case int n when (n >= 19 && n <= 23):
                    this.MaxCastingPower += 5;
                    break;
                case int n when (n >= 24 && n <= 28):
                    this.MaxCastingPower += 6;
                    break;
                case int n when (n >= 29 && n <= 33):
                    this.MaxCastingPower += 7;
                    break;
                case int n when (n >= 34 && n <= 38):
                    this.MaxCastingPower += 8;
                    break;
                case int n when (n >= 39 && n <= 43):
                    this.MaxCastingPower += 9;
                    break;
                case int n when (n >= 44 && n <= 48):
                    this.MaxCastingPower += 10;
                    break;
                case int n when (n == 49 || n == 50):
                    this.MaxCastingPower += 11;
                    break;
                default:
                    break;
            }

            Util.WriteLine("Casting power: +" + (this.MaxCastingPower - castingPower).ToString());

#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
        }

        public override void OnCreatureDied(ICreature dead)
        {
        }

        public override void OnCreatureHealed(ICreature healer)
        {
        }

        public override void OnDealDamage()
        {
        }

        public override void OnItemUnequipped(IItem item)
        {
        }

        public override void YourTurn(Encounter encounter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates the base wizard, at character creation.
        /// </summary>
        /// <returns></returns>
        private static CreatureAttributes GetAtt(Gender gender, Race race, Alignment alignment)
        {
            int startingHealth = Dice.RollDice(new Die(1, 4, 1), "Starting Health");
            return new CreatureAttributes(gender, alignment, race, .01, startingHealth, startingHealth,
            Dice.RollDice(new Die(3, 6, 0), "Dexterity"), Dice.RollDice(new Die(3, 6, 0), "Strength"),
            Dice.RollDice(new Die(3, 6, 0), "Constitution"), Dice.RollDice(new Die(3, 6, 0), "Charisma"),
            Dice.RollDice(new Die(3, 6, 0), "Wisdom"), 0, 0, 0, 0, 0, 0, 0, 0, true, 12, .4, 30, Dice.RollDice(new Die(3, 6, 0), "Intelligence"));
        }
    }
}