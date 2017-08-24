namespace EarthMagicItems.Gems
{
    using System;
    using System.Collections.Generic;
    using EarthMagicDynamicMarket;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;

    /// <summary>
    /// The generic class for a gem.
    /// </summary>
    public class GenericGem : IGem
    {
        public GenericGem(string name, double weight = .25, string imagePath = "", string documentationPath = "")
            : base(name, weight, imagePath, documentationPath)
        {
            this.Value = Pricer.GetPrice(this);
        }

        public override void Bought()
        {
        }

        public override bool CanEquip(ICreature creature)
        {
            return true;
        }

        public override void Sold()
        {
        }

        public override void SpellHit(ISpell spell)
        {
            //Need to handle dispels here.
            throw new NotImplementedException();
        }

        public override void Unequip()
        {
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