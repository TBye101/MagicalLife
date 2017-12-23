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
        /// <summary>
        /// The damage this item does when it is used to attack.
        /// </summary>
        private Damage damage = new Damage(Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), Util.Die.Zero(), new Util.Die(0, 0, 1));

        /// <summary>
        /// The resource path to the documentation about this item.
        /// </summary>
        private string documentationPath;

        /// <summary>
        /// Gets the impact an item has on the character when it is equipped.
        /// </summary>
        /// <returns></returns>
        private StatsImpact equipImpact = new StatsImpact();

        /// <summary>
        /// The ID of the item.
        /// </summary>
        private Guid iD = Guid.NewGuid();

        /// <summary>
        /// The resource path to the ASCII art image.
        /// </summary>
        private string imagePath;

        private bool isCursed = false;

        /// <summary>
        /// Holds whether or not the item is equipped.
        /// </summary>
        private bool isEquipped = false;

        /// <summary>
        /// The level of the item. Used to determine what loot table to put it on.
        /// </summary>
        private int level;

        /// <summary>
        /// The human readable name of the item.
        /// </summary>
        private string name;

        /// <summary>
        /// The name of the creature that possesses this item.
        /// </summary>
        private string owner = "";

        /// <summary>
        /// Returns if the item is a quest item.
        /// </summary>
        private bool questItem = false;

        /// <summary>
        /// The base value of the item, that if the player has 100% trading skills, they will get.
        /// </summary>
        private int value;

        /// <summary>
        /// The weight of the item.
        /// </summary>
        private double weight;

        public Damage Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                this.damage = value;
            }
        }

        public string DocumentationPath
        {
            get
            {
                return this.documentationPath;
            }

            set
            {
                this.documentationPath = value;
            }
        }

        public StatsImpact EquipImpact
        {
            get
            {
                return this.equipImpact;
            }

            set
            {
                this.equipImpact = value;
            }
        }

        public Guid ID
        {
            get
            {
                return this.iD;
            }

            set
            {
                this.iD = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                this.imagePath = value;
            }
        }

        public bool IsCursed
        {
            get
            {
                return this.isCursed;
            }

            set
            {
                this.isCursed = value;
            }
        }

        public bool IsEquipped
        {
            get
            {
                return this.isEquipped;
            }

            set
            {
                this.isEquipped = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }

            set
            {
                this.level = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                this.owner = value;
            }
        }

        public bool QuestItem
        {
            get
            {
                return this.questItem;
            }

            set
            {
                this.questItem = value;
            }
        }

        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                this.weight = value;
            }
        }

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
        /// Called whenever the creature tries to equip this.
        /// </summary>
        /// <returns></returns>
        public abstract bool CanEquip(ICreature creature);

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