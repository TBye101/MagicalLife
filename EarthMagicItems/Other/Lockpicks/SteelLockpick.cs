namespace EarthMagicItems.Other.Lockpicks
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;
    using EarthWithMagicAPI.API.Util;

    public class SteelLockpick : ILockpick
    {
        public SteelLockpick()
            : base(
                  "Steel Lockpick",
                  .25,
                  "EarthMagicDocumentation.ASCII_Art.Items.Other.Lockpick.txt",
                  "EarthMagicDocumentation.Items.Other.Lockpicks.SteelLockpick.md",
                  0)
        {
        }

        public override void Bought()
        {
        }

        public override bool CanEquip(ICreature creature)
        {
            Util.WriteLine("You don't need to equip lockpicks! The best one in your thief's inventory will be used.");
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
            throw new NotImplementedException();
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
