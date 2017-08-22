using EarthWithMagicAPI.API.Interfaces.Items;
namespace EarthMagicItems.Amulets.Clerical
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Spells;

    public class HolySymbolOfTali : IAmulet
    {
        public HolySymbolOfTali()
            : base("Holy Symbol of Tali", 3, "EarthMagicDocumentation.ASCII_Art.Items.Amulets.Clerical.HolySymbolOfTali.txt",
            "EarthMagicDocumentation.Items.Amulets.Clerical.HolySymbolOfTali.md")
        {
        }

        public override void Bought()
        {
            throw new NotImplementedException();
        }

        public override bool CanEquip(ICreature creature)
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
