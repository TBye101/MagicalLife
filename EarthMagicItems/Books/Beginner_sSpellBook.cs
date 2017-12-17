// <copyright file="Beginner_sSpellBook.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicItems.Books
{
    using System;
    using System.Collections.Generic;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Registry;
    using EarthWithMagicAPI.API.Stuff;

    /// <summary>
    /// The beginner's spellbook holds 3 random spells under power level 5.
    /// </summary>
    public class Beginner_sSpellBook : ISpellbook
    {
        public Beginner_sSpellBook()
            : base(
                  "Beginner's Spellbook",
                  2,
                  "EarthMagicDocumentation.ASCII_Art.Items.Books.Spellbook.txt",
                  "EarthMagicDocumentation.Items.Books.Spellbook.md")
        {
            Random a = new Random();
            List<ISpell> spells = SpellRegistry.GetSpellsUnderPower(5);

            this.Spells.Add(spells[a.Next(spells.Count)]);
            this.Spells.Add(spells[a.Next(spells.Count)]);
            this.Spells.Add(spells[a.Next(spells.Count)]);
        }

        public override void Bought()
        {
        }

        public override bool CanEquip(ICreature creature)
        {
            return false;
        }

        public override void Sold()
        {
        }

        public override void SpellHit(ISpell spell)
        {
        }

        public override void Unequip()
        {
            throw new Exception("How the heck did you equip this!?!?!?");
        }

        public override void Use(ICreature user, Encounter encounter)
        {
            throw new NotImplementedException();
        }

        public override void WeaponHit(IWeapon attacker)
        {
        }
    }
}