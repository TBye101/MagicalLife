using EarthWithMagicAPI.API.Creature;
using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;

namespace EarthWithMagicAPI.API.Interfaces.Items
{
    public abstract class IItem
    {
        protected IItem(string name, double weight, string imagePath, string documentationPath)
        {
            this.Name = name;
            this.Weight = weight;
            this.ImagePath = imagePath;
            this.DocumentationPath = documentationPath;
        }

        /// <summary>
        /// The resource path to the ASCII art image.
        /// </summary>
        public string ImagePath;

        /// <summary>
        /// The resource path to the documentation about this item.
        /// </summary>
        public string DocumentationPath;

        /// <summary>
        /// The damage this item does when it is used to attack.
        /// </summary>
        public Damage Damage = new Damage(Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), new Util.Die(0, 0, 1));

        /// <summary>
        /// The ID of the item.
        /// </summary>
        public Guid ID = new Guid();

        public bool IsCursed = false;

        /// <summary>
        /// Holds whether or not the item is equipped.
        /// </summary>
        public bool IsEquipped = false;

        /// <summary>
        /// The level of the item. Used to determine what loot table to put it on.
        /// </summary>
        public int Level;

        /// <summary>
        /// The human readable name of the item.
        /// </summary>
        public string Name;

        /// <summary>
        /// The name of the creature that possesses this item.
        /// </summary>
        public string Owner = "";

        /// <summary>
        /// Returns if the item is a quest item.
        /// </summary>
        public bool QuestItem = false;

        /// <summary>
        /// The base value of the item, that if the player has 100% trading skills, they will get.
        /// </summary>
        public int Value;

        /// <summary>
        /// The weight of the item.
        /// </summary>
        public double Weight;

        /// <summary>
        /// Called whenever the item is bought.
        /// </summary>
        public abstract void Bought();

        /// <summary>
        /// Called whenever the creature tries to equip this.
        /// </summary>
        /// <returns></returns>
        public abstract bool CanEquip(ICreature creature);

        /// <summary>
        /// Gets the impact an item has on the character when it is equipped.
        /// </summary>
        /// <returns></returns>
        public StatsImpact EquipImpact = new StatsImpact();

        /// <summary>
        /// Called whenever the item is sold.
        /// </summary>
        public abstract void Sold();

        /// <summary>
        /// Called whenever the player is hit by a spell, such as a dispel.
        /// </summary>
        /// <param name="spell"></param>
        public abstract void SpellHit(ISpell spell);

        /// <summary>
        /// Called whenever the player equips the item.
        /// </summary>
        /// <summary>
        /// Called whenever the player un equips the item.
        /// </summary>
        public abstract void Unequip();

        /// <summary>
        /// If the item has a special ability, or can be consumed it should happen when this is called.
        /// </summary>
        public abstract void Use();

        /// <summary>
        /// Called whenever the player is hit by a weapon.
        /// </summary>
        /// <param name="attacker"></param>
        public abstract void WeaponHit(IWeapon attacker);
    }

    /// <summary>
    /// Holds the impact an item will have on a player's stats.
    /// Ex: If you set Strength to -2, the player that equips this will have their strength lowered by 2.
    /// </summary>
    public class StatsImpact
    {
        public int AC = 0;
        public int AcidResistance = 0;
        public int Charisma = 0;
        public int CharmResistance = 0;
        public int ColdResistance = 0;
        public int Constitution = 0;
        public int Dexterity = 0;
        public int Dodge = 0;
        public int ElectricResistance = 0;
        public int FireResistance = 0;
        public int Health = 0;
        public int Initiative = 0;
        public int MagicResistance = 0;
        public int PoisonResistance = 0;
        public int SleepResistance = 0;
        public int Strength = 0;
        public int WeightCapacity = 0;
        public int Wisdom = 0;

        public StatsImpact()
        {

        }

        public StatsImpact(int charisma, int dexterity, int strength, int constitution, int wisdom, int ac,
            int health, int weightCapacity, int fireResistance, int acidResistance, int poisonResistance, int electricResistance, int coldResistance, int magicResistance, int charmResistance,
            int sleepResistance, int initiative, int dodge)
        {
            this.Charisma = charisma;
            this.Dexterity = dexterity;
            this.Strength = strength;
            this.Constitution = constitution;
            this.Wisdom = wisdom;

            this.AC = ac;
            this.Health = health;
            this.WeightCapacity = weightCapacity;
            this.FireResistance = fireResistance;
            this.AcidResistance = acidResistance;
            this.PoisonResistance = poisonResistance;
            this.ElectricResistance = electricResistance;
            this.ColdResistance = coldResistance;
            this.MagicResistance = magicResistance;
            this.CharmResistance = charmResistance;
            this.SleepResistance = sleepResistance;
            this.Initiative = initiative;
            this.Dodge = dodge;
        }
    }
}