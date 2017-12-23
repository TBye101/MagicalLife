// <copyright file="LeatherBootsOfSoftStepping.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicItems.Armor.Boots
{
    using System;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;

    public class LeatherBootsOfSoftStepping : IArmor
    {
        public LeatherBootsOfSoftStepping()
            : base(
                "Leather Boots of Soft Stepping",
                  1,
                  "EarthMagicDocumentation.ASCII_Art.Items.Armor.Boots.LeatherBootsOfSoftStepping.txt",
                "EarthMagicDocumentation.Items.Armor.Boots.LeatherBootsOfSoftStepping.md")
        {
            this.EquipImpact.WalkSilently = 20;
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
            throw new NotImplementedException();//Handle dispel
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