// <copyright file="GenericAmmo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicItems.Ammo.Arrows
{
    using EarthMagicDynamicMarket;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;
    using EarthWithMagicAPI.API.Util;
    using System;

    public class GenericAmmo : IAmmo
    {
        public GenericAmmo(Die uses, string name, Damage attackDamage, string imagePath, string documentationPath, double weight) : base(name, weight, imagePath, documentationPath)
        {
            this.Uses = uses;
            this.Name = name;
            this.AttackDamage = attackDamage;
            this.Value = Pricer.GetPrice(this);
            this.ID = Guid.NewGuid();
            this.IsEquipped = false;
            this.Weight = .05;
        }

        public override void Bought()
        {
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
            //Need to handle a dispell.
            throw new NotImplementedException();
        }

        public override void Unequip()
        {
        }

        public override void Use(ICreature user)
        {
            throw new NotImplementedException();
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