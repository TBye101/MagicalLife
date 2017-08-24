namespace EarthMagicItems.Weapons.Normal.Daggers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;
    using EarthWithMagicAPI.API.Util;

    public class Dagger : IWeapon
    {
        public Dagger()
            : base(
                new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 5, 0), Die.Zero()),
                  "Dagger",
                  .75,
                  "EarthMagicDocumentation.ASCII_Art.Items.Weapons.Normal.Daggers.Dagger.txt",
                  "EarthMagicDocumentation.Items.Weapons.Normal.Daggers.Dagger.md")
        {
        }

        public override void Bought()
        {
        }

        public override bool CanEquip(ICreature creature)
        {
            return true;
        }

        public override void OnAttack()
        {
        }

        public override void OnThrow()
        {
        }

        public override void Sold()
        {
        }

        public override void SpellHit(ISpell spell)
        {
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
