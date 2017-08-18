using EarthMagicDynamicMarket;
using EarthWithMagicAPI.API.Creature;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;

namespace EarthMagicItems.Armor
{
    /// <summary>
    /// Used to reduce boilerplate code for the simpler armor.
    /// </summary>
    public class GenericArmor : IArmor
    {
        public GenericArmor(int armorClass, string name)
        {
            this.AC = armorClass;
            this.QuestItem = questItem;
            this.Level = level;
            this.OtherInformation = otherInformation;
            this.Lore = lore;
            this.Name = name;
            this.Value = Pricer.GetPrice(this);
            this.ID = new Guid();
            this.IsEquipped = false;
            this.Weight = 5;
        }

        public override void Bought()
        {
        }

        public override bool CanEquip(ICreature creature)
        {
            return true;
        }

        public override StatsImpact EquipImpact()
        {
            throw new NotImplementedException();
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

        public override void Use()
        {
            throw new NotImplementedException();
        }

        public override void WeaponHit(IWeapon attacker)
        {
        }
    }
}