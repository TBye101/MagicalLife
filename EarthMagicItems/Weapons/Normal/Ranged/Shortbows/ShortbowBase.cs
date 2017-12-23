namespace EarthMagicItems.Weapons.Normal.Ranged.Shortbows
{
    using System;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;

    /// <summary>
    /// Shortbow item class.
    /// </summary>
    public class ShortbowBase : IRangedWeapon
    {
        protected ShortbowBase(Damage damage, string name, double weight, string imagePath, string documentationPath, int range, IAmmo ammo) : base(damage, name, weight, imagePath, documentationPath, range, ammo)
        {
        }

        public override void Bought()
        {
        }

        public override bool CanEquip(ICreature creature)
        {
            throw new NotImplementedException();
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
        }

        public override void WeaponHit(IWeapon attacker)
        {
        }
    }
}
