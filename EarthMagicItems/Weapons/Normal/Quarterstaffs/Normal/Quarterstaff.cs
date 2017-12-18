using EarthMagicCharacters.Classes.Monk.Generic_Monk;
namespace EarthMagicItems.Weapons.Normal.Quarterstaffs.Normal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthMagicCharacters.Classes;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;

    /// <summary>
    /// A basic quarterstaff.
    /// </summary>
    public class Quarterstaff : IWeapon
    {
        public Quarterstaff()
            : base(
                new Damage(new EarthWithMagicAPI.API.Util.Die(1, 6, 0), DamageType.Blunt),
                  "Quarterstaff",
                  5.5,
                  "EarthMagicDocumentation.ASCII_Art.Items.Weapons.Normal.Quarterstaffs.Quarterstaff.txt",
                  "EarthMagicDocumentation.Items.Weapons.Normal.Quarterstaff.Quarterstaff.md")
        {

        }
        public override void Bought()
        {
        }

        public override bool CanEquip(ICreature creature)
        {
            //Don't allow monk or shapeshifter
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
