using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;

namespace EarthWithMagicAPI.API.Interfaces.Items
{
    public interface IItem
    {
        /// <summary>
        /// Holds whether or not the item is equipped.
        /// </summary>
        bool IsEquipped { get; }

        /// <summary>
        /// Returns if the item is a quest item.
        /// </summary>
        bool QuestItem { get; set; }

        /// <summary>
        /// The base value of the item, that if the player has 100% trading skills, they will get.
        /// </summary>
        int Value { get; }

        /// <summary>
        /// The level of the item. Used to determine what loot table to put it on.
        /// </summary>
        int Level { get; }

        /// <summary>
        /// The ID of the item.
        /// </summary>
        Guid ID { get; }

        /// <summary>
        /// The human readable name of the item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The flavor text/lore of the item.
        /// </summary>
        List<string> Lore { get; }

        /// <summary>
        /// Any other information the item might display.
        /// </summary>
        List<string> OtherInformation { get; }

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

        void Equip();

        /// <summary>
        /// Called whenever the player un equips the item.
        /// </summary>
        void Unequip();

        /// <summary>
        /// Called whenever the player is hit by a spell, such as a dispel.
        /// </summary>
        void SpellHit(ISpell spell);

        /// <summary>
        /// Called whenever the item is sold.
        /// </summary>
        void Sold();

        /// <summary>
        /// Called whenever the item is bought.
        /// </summary>
        void Bought();

        /// <summary>
        /// Called whenever the player is hit by a weapon.
        /// </summary>
        /// <param name="attacker"></param>
        void WeaponHit(IWeapon attacker);
    }
}