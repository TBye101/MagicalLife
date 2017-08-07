﻿using EarthMagicDynamicMarket;
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

        public GenericArmor(int armorClass, bool questItem, int level, List<string> otherInformation, List<string> lore, string name)
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

        public event EventHandler<IItem> ItemSold;

        public event EventHandler<IItem> ItemBought;

        public event EventHandler<IItem> ItemDropped;

        public event EventHandler<IItem> ItemPickedUp;

        public event EventHandler<IItem> ItemLost;

        public event EventHandler<IItem> ItemThrown;

        public event EventHandler<IItem> ItemDestroyed;

        public event EventHandler<IItem> ItemEquipped;

        public event EventHandler<IItem> StatusChanged;

        public override void Bought()
        {
        }

        public override void Equip()
        {
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

        public override void WeaponHit(IWeapon attacker)
        {
        }
    }
}