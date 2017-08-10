using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;

namespace EarthWithMagicAPI.API.Interfaces.Items
{
    /// <summary>
    /// Holds the impact an item will have on a player's stats.
    /// Ex: If you set Strength to -2, the player that equips this will have their strength lowered by 2.
    /// </summary>
    public struct StatsImpact
    {
        public int Charisma;
        public int Dexterity;
        public int Strength;
        public int Constitution;
        public int Wisdom;

        public StatsImpact(int charisma, int dexterity, int strength, int constitution, int wisdom)
        {
            this.Charisma = charisma;
            this.Dexterity = dexterity;
            this.Strength = strength;
            this.Constitution = constitution;
            this.Wisdom = wisdom;
        }
    }

    public abstract class IItem
    {
        /// <summary>
        /// Gets the impact an item has on the character when it is equipped.
        /// </summary>
        /// <returns></returns>
        public abstract StatsImpact EquipImpact();

        public bool IsCursed = false;
        /// <summary>
        /// The weight of the item.
        /// </summary>
        public double Weight;

        /// <summary>
        /// Holds whether or not the item is equipped.
        /// </summary>
        public bool IsEquipped = false;

        /// <summary>
        /// Returns if the item is a quest item.
        /// </summary>
        public bool QuestItem = false;

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
        public event EventHandler<IItem> ItemSold;

        /// <summary>
        /// Raised whenever an item is bought.
        /// </summary>
        public event EventHandler<IItem> ItemBought;

        /// <summary>
        /// Raised whenever an item is dropped on the ground.
        /// </summary>
        public event EventHandler<IItem> ItemDropped;

        /// <summary>
        /// Raised whenever an item is picked up.
        /// </summary>
        public event EventHandler<IItem> ItemPickedUp;

        /// <summary>
        /// Raised whenever an item is lost.
        /// Ex: Given to another player, or removed from an inventory due to a quest.
        /// </summary>
        public event EventHandler<IItem> ItemLost;

        /// <summary>
        /// Raised whenever an item is thrown.
        /// </summary>
        public event EventHandler<IItem> ItemThrown;

        /// <summary>
        /// Raised whenever an item is destroyed.
        /// </summary>
        public event EventHandler<IItem> ItemDestroyed;

        /// <summary>
        /// Raised whenever an item is equipped.
        /// </summary>
        public event EventHandler<IItem> ItemEquipped;

        /// <summary>
        /// Raised whenever an item has it's status changed, such as being temporarily dispelled. This just means the player's stats need to be recalculated.
        /// </summary>
        public event EventHandler<IItem> StatusChanged;

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