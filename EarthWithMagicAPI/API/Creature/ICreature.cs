using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Holds various things that every creature has or should implement.
    /// </summary>
    public abstract class ICreature
    {
        /// <summary>
        /// The creature's name, if it has one.
        /// </summary>
        public string Name;

        /// <summary>
        /// The name of the type of creature the creature is.
        /// </summary>
        public string CreatureType;

        /// <summary>
        /// The unique ID of the creature.
        /// </summary>
        public Guid ID;

        /// <summary>
        /// Some attributes of the creature.
        /// </summary>
        public CreatureAttributes Attributes;

        /// <summary>
        /// All the equipped armor that the creature has.
        /// </summary>
        public List<IArmor> Armoring;

        /// <summary>
        /// All of the equipped rings that the creature has.
        /// </summary>
        public List<IRing> Rings;

        /// <summary>
        /// All of the equipped amulets that the creature has.
        /// </summary>
        public List<IAmulet> Amulets;

        /// <summary>
        /// The equipped weapons that the creature has.
        /// </summary>
        public List<IWeapon> Weapons;

        /// <summary>
        /// Called whenever the creature receives damage.
        /// </summary>
        /// <param name="damage"></param>
        public abstract void OnRecieveDamage(Damage damage);

        /// <summary>
        /// Called whenever the creature has a new item equipped.
        /// </summary>
        /// <param name="item"></param>
        public abstract void OnItemEquipped(IItem item);

        /// <summary>
        /// Called whenever the creature has a item unequipped.
        /// </summary>
        /// <param name="item"></param>
        public abstract void OnItemUnequipped(IItem item);

        /// <summary>
        /// Called whenever the creature is healed.
        /// </summary>
        /// <param name="healer">The creature that healed this creature.</param>
        public abstract void OnCreatureHealed(ICreature healer);

        /// <summary>
        /// Called whenever a creature dies.
        /// </summary>
        /// <param name="dead">The creature that is now dead.</param>
        public abstract void OnCreatureDied(ICreature dead);

        /// <summary>
        /// Called whenever this creature deals damage.
        /// </summary>
        public abstract void OnDealDamage();

        /// <summary>
        /// Raised whenever a creature takes damage.
        /// </summary>
        public event EventHandler<Damage> TakeDamageEvent;

        /// <summary>
        /// Raised whenever a creature deals damage to another creature.
        /// </summary>
        public event EventHandler<Damage> DealDamageEvent;

        /// <summary>
        /// Raised whenever a new item is equipped.
        /// </summary>
        public event EventHandler<ICreature> ItemEquipped;

        /// <summary>
        /// Raised whenever a item is unequipped.
        /// </summary>
        public event EventHandler<ICreature> ItemUnequipped;

        /// <summary>
        /// Raised whenever a creature dies.
        /// </summary>
        public event EventHandler<ICreature> CreatureDied;

        /// <summary>
        /// Raised whenever a creature is healed.
        /// </summary>
        public event EventHandler<ICreature> CreatureHealed;

    }
}
