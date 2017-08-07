using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;

namespace EarthWithMagicAPI.API.Interfaces.Items
{
    public abstract class IItem
    {
        /// <summary>
        /// The weight of the item.
        /// </summary>
        public double Weight;

        /// <summary>
        /// Holds whether or not the item is equipped.
        /// </summary>
        public bool IsEquipped;

        /// <summary>
        /// Returns if the item is a quest item.
        /// </summary>
        public bool QuestItem;

        /// <summary>
        /// The base value of the item, that if the player has 100% trading skills, they will get.
        /// </summary>
        public int Value;

        /// <summary>
        /// The level of the item. Used to determine what loot table to put it on.
        /// </summary>
        public int Level;

        /// <summary>
        /// The ID of the item.
        /// </summary>
        public Guid ID = new Guid();

        /// <summary>
        /// The human readable name of the item.
        /// </summary>
        public string Name;

        /// <summary>
        /// The flavor text/lore of the item.
        /// </summary>
        public List<string> Lore;

        /// <summary>
        /// Any other information the item might display.
        /// </summary>
        public List<string> OtherInformation;

        /// <summary>
        /// Raised whenever an item is sold.
        /// </summary>
        event EventHandler<IItem> ItemSold;

        /// <summary>
        /// Raised whenever an item is bought.
        /// </summary>
        event EventHandler<IItem> ItemBought;

        /// <summary>
        /// Raised whenever an item is dropped on the ground.
        /// </summary>
        event EventHandler<IItem> ItemDropped;

        /// <summary>
        /// Raised whenever an item is picked up.
        /// </summary>
        event EventHandler<IItem> ItemPickedUp;

        /// <summary>
        /// Raised whenever an item is lost.
        /// Ex: Given to another player, or removed from an inventory due to a quest.
        /// </summary>
        event EventHandler<IItem> ItemLost;

        /// <summary>
        /// Raised whenever an item is thrown.
        /// </summary>
        event EventHandler<IItem> ItemThrown;

        /// <summary>
        /// Raised whenever an item is destroyed.
        /// </summary>
        event EventHandler<IItem> ItemDestroyed;

        /// <summary>
        /// Raised whenever an item is equipped.
        /// </summary>
        event EventHandler<IItem> ItemEquipped;

        /// <summary>
        /// Raised whenever an item has it's status changed, such as being temporarily dispelled. This just means the player's stats need to be recalculated.
        /// </summary>
        event EventHandler<IItem> StatusChanged;

        /// <summary>
        /// Called whenever the player equips the item.
        /// </summary>

        public abstract void Equip();

        /// <summary>
        /// Called whenever the player un equips the item.
        /// </summary>
        public abstract void Unequip();

        /// <summary>
        /// Called whenever the player is hit by a spell, such as a dispel.
        /// </summary>
        public abstract void SpellHit(ISpell spell);

        /// <summary>
        /// Called whenever the item is sold.
        /// </summary>
        public abstract void Sold();

        /// <summary>
        /// Called whenever the item is bought.
        /// </summary>
        public abstract void Bought();

        /// <summary>
        /// Called whenever the player is hit by a weapon.
        /// </summary>
        /// <param name="attacker"></param>
        public abstract void WeaponHit(IWeapon attacker);
    }
}