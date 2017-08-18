using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;

namespace EarthWithMagicAPI.API.Creature
{
    public class Fists : IWeapon
    {
        public Fists() : base(new Damage(Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(),
        Util.Die.Zero(), Util.Die.Zero(), new Util.Die(1, 2, 0)),
            "Fists", 0, "EarthMagicDocumentation.ASCII_Art.Items.Fists.txt", "EarthMagicDocumentation.Items.Fists.md")
        {
            this.IsEquipped = false;
            this.Level = -1;
            this.QuestItem = false;
            this.Value = 0;
        }

        public override void Bought()
        {
            throw new NotImplementedException();
        }

        public override bool CanEquip(ICreature creature)
        {
            return true;
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