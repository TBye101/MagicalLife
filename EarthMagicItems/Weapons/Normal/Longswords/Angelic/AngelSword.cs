namespace EarthMagicItems.Weapons.Normal.Longswords.Angelic
{
    using System;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;
    using EarthWithMagicAPI.API.Util;

    public class AngelSword : IWeapon
    {
        public AngelSword() : base(new EarthWithMagicAPI.API.Damage(
                Die.Zero(), Die.Zero(), Die.Zero(), new Die(2, 8, 6), Die.Zero(), Die.Zero(), Die.Zero(), new Die(2, 8, 6), Die.Zero()),
            "Angel Sword", 4, "EarthMagicDocumentation.ASCII_Art.Items.Weapons.Normal.Scimitars.AngelSword.txt",
            "EarthMagicDocumentation.Items.Weapons.Normal.Scimitars.AngelSword.md")
        {
        }

        public override void Bought()
        {
            throw new Exception("These shouldn't be sold anywhere!");
        }

        public override bool CanEquip(ICreature creature)
        {
            if (creature.IsMortal)
            {
                Util.WriteLine("I will not allow a mere mortal to wield me!");
                creature.RecieveDamage(new EarthWithMagicAPI.API.Damage(Die.Zero(), Die.Zero(), new Die(1, 100, 10), new Die(1, 100, 10), Die.Zero(), new Die(1, 100, 10), Die.Zero(),
                    Die.Zero(), Die.Zero()));
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void OnAttack()
        {
            throw new NotImplementedException();
        }

        public override void OnThrow()
        {
            throw new NotImplementedException();
        }

        public override void Sold()
        {
            throw new NotImplementedException();
        }

        public override void SpellHit(ISpell spell)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}