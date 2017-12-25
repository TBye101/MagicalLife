// <copyright file="IItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Interfaces.Items
{
    using System;
    using EarthMagicDocumentation;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;

    public abstract class IItem
    {

        public Damage Damage { get; set; } = new Damage(Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), new Util.Die(0, 0, 1));

        public string DocumentationPath { get; set; }

        public StatsImpact EquipImpact { get; set; } = new StatsImpact();

        public Guid ID { get; set; } = Guid.NewGuid();

        public string ImagePath { get; set; }

        public bool IsCursed { get; set; } = false;

        public bool IsEquipped { get; set; } = false;

        public int Level { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; } = "";

        public bool QuestItem { get; set; } = false;

        public int Value { get; set; }

        public double Weight { get; set; }

        public UsabilityDescription Usability { get; set; } = new UsabilityDescription();

        protected IItem(string name, double weight, string imagePath, string documentationPath)
        {
            this.Name = name;
            this.Weight = weight;
            this.ImagePath = imagePath;
            this.DocumentationPath = documentationPath;
        }

        /// <summary>
        /// Called whenever the item is bought.
        /// </summary>
        public abstract void Bought();

        /// <summary>
        /// Displays information about this item.
        /// </summary>
        public void DisplayDocumentation()
        {
            Util.Util.WriteLine(ResourceGM.GetResource(this.DocumentationPath));
        }

        /// <summary>
        /// Displays the image of this item.
        /// </summary>
        public void DisplayImage()
        {
            Util.Util.WriteLine(ResourceGM.GetResource(this.ImagePath));
        }

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
        /// <param name="user"></param>
        public abstract void Use(ICreature user);

        /// <summary>
        /// Called when an item is used during a battle. May have different results than the other Use().
        /// </summary>
        /// <param name="user"></param>
        /// <param name="encounter"></param>
        public abstract void Use(ICreature user, Encounter encounter);

        /// <summary>
        /// Called whenever the player is hit by a weapon.
        /// </summary>
        /// <param name="attacker"></param>
        public abstract void WeaponHit(IWeapon attacker);
    }
}