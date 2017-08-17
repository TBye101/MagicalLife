using EarthMagicDynamicMarket;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Interfaces.Spells;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;

namespace EarthMagicItems.Ammo.Arrows
{
    public class GenericAmmo : IAmmo
    {
        public GenericAmmo(Die uses, bool questItem, int level, string name, int chanceToHit, Damage attackDamage, List<string> lore, List<string> otherInfo)
        {
            this.Uses = uses;
            this.QuestItem = questItem;
            this.Level = level;
            this.Name = name;
            this.ChanceToHit = chanceToHit;
            this.AttackDamage = attackDamage;
            this.Lore = lore;
            this.OtherInformation = otherInfo;
            this.Value = Pricer.GetPrice(this);
            this.ID = new Guid();
            this.IsEquipped = false;
            this.Weight = .05;
        }

        public override void Bought()
        {
        }

        public override void Equip()
        {
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
            //Need to handle a dispell.
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