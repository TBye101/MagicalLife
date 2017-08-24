namespace EarthMagicItems.Amulets.Clerical
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthMagicCharacters.Classes.Cleric.Generic_Cleric;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;
    using EarthWithMagicAPI.API.Util;

    public class HolySymbolOfTali : IAmulet
    {
        public HolySymbolOfTali()
            : base("Holy Symbol of Tali", 3, "EarthMagicDocumentation.ASCII_Art.Items.Amulets.Clerical.HolySymbolOfTali.txt", "EarthMagicDocumentation.Items.Amulets.Clerical.HolySymbolOfTali.md")
        {
        }

        public override void Bought()
        {
        }

        public override bool CanEquip(ICreature creature)
        {
            if (creature.GetType() == typeof(GenericCleric))
            {
                return true;
            }
            else
            {
                Util.WriteLine("Only a true cleric of Tali can use this amulet!");
                creature.RecieveDamage(new Damage(Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 10, 2), Die.Zero(), new Die(1, 10, 2), Die.Zero(), Die.Zero(), Die.Zero()));
                return false;
            }
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

        public override void Use(ICreature user)
        {
            Util.WriteLine("No enemies to smite!");
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
