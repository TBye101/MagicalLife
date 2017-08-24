namespace EarthMagicCharacters.Classes.Cleric.Generic_Cleric
{
    using System;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Util;

    public class GenericCleric : ICharacter
    {
        private bool hostile;

        public GenericCleric(Gender gender, Race race, Alignment alignment, string name = "Cleric", bool isHostile = false)
            : base(GetAtt(gender, race, alignment), new CreatureAbilities(), "EarthMagicDocumentation.Classes.Cleric_Class_Info.md", "EarthMagicDocumentation.ASCII_Art.Cleric.txt", new ClericAI())
        {
            this.creatureType = CreatureType.Humanoid;
            this.Abilities.BasePrayers = 1;
            this.Name = name;
            this.hostile = isHostile;
        }

        private static CreatureAttributes GetAtt(Gender gender, Race race, Alignment alignment)
        {
            int startingHealth = Dice.RollDice(new Die(2, 10, 3), "Starting Health");
            return new CreatureAttributes(gender, alignment, race, .06, startingHealth, startingHealth,
            Dice.RollDice(new Die(3, 6, 0), "Dexterity"), Dice.RollDice(new Die(3, 6, 0), "Strength"),
            Dice.RollDice(new Die(3, 6, 0), "Constitution"), Dice.RollDice(new Die(3, 6, 0), "Charisma"),
            Dice.RollDice(new Die(3, 6, 0), "Wisdom"), 0, 0, 0, 0, 0, 0, 0, 0, true, 8, .4, 30, Dice.RollDice(new Die(3, 6, 0), "Intelligence"));
        }

        public override void EquipItem(IItem item)
        {
        }

        public override bool IsHostile()
        {
            return this.hostile;
        }

        public override void LevelUp()
        {
            this.Attributes.BaseHealth += Dice.RollDice(new Die(1, 10, 3), this.Name + " gains hit points: ");

            if (this.Attributes.XP.CreatureLevel < 51 && this.Attributes.XP.CreatureLevel != 24)
            {
                this.Abilities.BasePrayers++;
            }

            if (this.Attributes.XP.CreatureLevel == 50 || this.Attributes.XP.CreatureLevel == 24)
            {
                this.Attributes.BaseWisdom++;
            }
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
    }
}