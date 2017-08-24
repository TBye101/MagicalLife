using EarthWithMagicAPI.API;
// <copyright file="HolySymbolOfTali.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicItems.Amulets.Clerical
{
    using EarthMagicCharacters.Classes.Cleric.Generic_Cleric;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;
    using EarthWithMagicAPI.API.Util;
    using System;

    public class HolySymbolOfTali : IAmulet
    {
        public HolySymbolOfTali()
            : base("Holy Symbol of Tali", 3, "EarthMagicDocumentation.ASCII_Art.Items.Amulets.Clerical.HolySymbolOfTali.txt", "EarthMagicDocumentation.Items.Amulets.Clerical.HolySymbolOfTali.md")
        {
        }

        public override void Bought()
        {
        }

        public override bool CanEquip(ICreature creature)
        {
            if (creature.GetType() == typeof(GenericCleric))
            {
                return true;
            }
            else
            {
                Util.WriteLine("Only a true cleric of Tali can use this amulet!");
                creature.RecieveDamage(new Damage(Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 10, 2), Die.Zero(), new Die(1, 10, 2), Die.Zero(), Die.Zero(), Die.Zero()));
                return false;
            }
        }

        public override void Sold()
        {
        }

        public override void SpellHit(ISpell spell)//Need to handle dispels, and spells from evil casters.
        {
            throw new NotImplementedException();
        }

        public override void Unequip()
        {
        }

        public override void Use(ICreature user)
        {
            Util.WriteLine("No enemies to smite!");
        }

        public override void Use(ICreature user, Encounter encounter)
        {
            Damage a = new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die((user.Attributes.XP.CreatureLevel / 10) + 1, user.Attributes.XP.CreatureLevel / 2, 1), Die.Zero(), Die.Zero(), Die.Zero());
            if (user.IsHostile())
            {
                foreach (ICreature item in encounter.Party)
                {
                    if (item.creatureType == CreatureType.Undead || item.creatureType == CreatureType.Demonic)
                    {
                        int chance = Dice.RollDice(new Die(1, 100, 0), "I pray to Tali for a divine smite!");

                        if (this.Smite(user, item))
                        {
                            item.RecieveDamage(a);
                        }
                    }
                }
            }
            else
            {
                foreach (ICreature item in encounter.Enemies)
                {
                    if (item.creatureType == CreatureType.Undead || item.creatureType == CreatureType.Demonic)
                    {
                        int chance = Dice.RollDice(new Die(1, 100, 0), "I pray to Tali for a divine smite!");

                        if (this.Smite(user, item))
                        {
                            item.RecieveDamage(a);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Returns whether or not the creature should be smited.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool Smite(ICreature user, ICreature target)
        {
            int totalLevels = user.Attributes.XP.CreatureLevel + target.Attributes.XP.CreatureLevel;

            int chance = user.Attributes.XP.CreatureLevel;

            int result = Dice.RollDice(new Die(1, totalLevels, 0), "Chance of smiting!");

            Util.WriteLine("Roll needs to be lower than " + chance.ToString() + " for the smite to work!");

            return result < chance;
        }

        public override void WeaponHit(IWeapon attacker)
        {
        }
    }
}