namespace EarthMagicItems.Armor
{
    using System;
    using System.Collections.Generic;
    using EarthMagicDynamicMarket;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;

    /// <summary>
    /// Used to reduce boilerplate code for the simpler armor.
    /// </summary>
    public class GenericArmor : IArmor
    {
        public GenericArmor(int armorClass, string name, double weight, string imagePath = "", string documentationPath = "") : base(name, weight, imagePath, documentationPath)
        {
            this.EquipImpact.AC = armorClass;
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
            //Need to handle spells such as a dispel here.
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