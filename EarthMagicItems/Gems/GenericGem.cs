using EarthMagicDynamicMarket;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;
using EarthWithMagicAPI.API.Creature;

namespace EarthMagicItems.Gems
{
    /// <summary>
    /// The generic class for a gem.
    /// </summary>
    public class GenericGem : IGem
    {
        public GenericGem(bool questItem, int level, List<string> otherInformation, List<string> lore, string name)
        {
            this.Value = Pricer.GetPrice(this);
            this.QuestItem = questItem;
            this.Level = level;
            this.ID = new Guid();
            this.Name = name;
            this.Lore = lore;
            this.OtherInformation = otherInformation;
            this.IsEquipped = false;
            this.Weight = .3;
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
            //Need to handle dispels here.
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