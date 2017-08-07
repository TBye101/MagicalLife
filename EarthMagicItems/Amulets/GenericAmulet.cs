using EarthMagicDynamicMarket;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;

namespace EarthMagicItems.Amulets
{
    /// <summary>
    /// A generic amulet.
    /// </summary>
    public class GenericAmulet : IItem
    {
        public GenericAmulet(bool questItem, bool isEquipped, int level, List<string> otherInformation, List<string> lore, string name)
        {
            this.QuestItem = questItem;
            this.IsEquipped = false;
            this.Level = level;
            this.OtherInformation = otherInformation;
            this.Lore = lore;
            this.Name = name;
            this.ID = new Guid();
            this.Value = Pricer.GetPrice(this);
            this.Weight = 1;
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
            //Need to handle a dispel
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