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
        }

        public override bool CanEquip(ICreature creature)
        {
            throw new NotImplementedException();
        }

        public override void Sold()
        {
        }

        public override void SpellHit(ISpell spell)//Need to handle dispels, and spells from evil casters.
        {
            throw new NotImplementedException();
        }

        public override void Unequip()
        {
        }

        public override void Use()
        {
            throw new NotImplementedException();
        }

        public override void WeaponHit(IWeapon attacker)
        {
        }
    }
}
