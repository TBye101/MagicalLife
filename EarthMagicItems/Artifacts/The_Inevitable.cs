// <copyright file="The Inevitable.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DungeonsAndFantasyLands.API.Items.Ammo.Arrows.Artifacts
{
    using EarthMagicDynamicMarket;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;
    using EarthWithMagicAPI.API.Util;
    using System;

    /// <summary>
    /// Before magical arrows were common for folks who could afford them, legend has it that a sorcerer made a magical and sentient arrow.
    /// The sentient arrow served it's master well, and was named "The Inevitable". Some say that if you get close to it, you can hear the screams of the lives it has taken.
    /// </summary>
    public class The_Inevitable : IAmmo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="The_Inevitable"/> class.
        /// The constructor for The_Inevitable.
        /// </summary>
        public The_Inevitable()
            : base("The Inevitable", .2, "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Special.TheInevitable.txt", "EarthMagicDocumentation.Items.Ammo.Special.TheInevitable.md")
        {
            this.AttackDamage = new Damage(new Die(2, 8, 5), new Die(2, 8, 5), new Die(2, 8, 5), new Die(2, 8, 5), new Die(2, 8, 5), new Die(2, 8, 5), new Die(2, 8, 5), Die.Zero(), Die.Zero());
            this.Uses = new Die(-1, -1, 0);
            this.ChanceToHit = 100;
            this.QuestItem = false;
            this.Level = 11;

            this.Name = "The Inevitable";
            this.ID = Guid.NewGuid();

            this.Value = Pricer.GetPrice(this);
        }

        public override void Bought()
        {
            throw new NotImplementedException();
        }

        public override bool CanEquip(ICreature creature)
        {
            return true;
        }

        public override void Sold()
        {
        }

        public override void SpellHit(ISpell spell)
        {
            //Gotta handle a dispel here
            throw new NotImplementedException();
        }

        public override void Unequip()
        {
        }

        public override void Use(ICreature user)
        {
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