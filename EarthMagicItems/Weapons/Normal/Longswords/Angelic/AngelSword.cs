using EarthWithMagicAPI.API.Util;
using EarthWithMagicAPI.API.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Text;
using EarthWithMagicAPI.API.Interfaces.Spells;
using EarthWithMagicAPI.API.Creature;

namespace EarthMagicItems.Weapons.Normal.Longswords.Angelic
{
    public class AngelSword : IWeapon
    {
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

        public override StatsImpact EquipImpact()
        {
            throw new NotImplementedException();
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

        public override void Use()
        {
            throw new NotImplementedException();
        }

        public override void WeaponHit(IWeapon attacker)
        {
            throw new NotImplementedException();
        }
    }
}
