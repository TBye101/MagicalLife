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
    public interface ICreature
    {
        /// <summary>
        /// The creature's name, if it has one.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The name of the type of creature the creature is.
        /// </summary>
        string CreatureType { get; set; }

        /// <summary>
        /// The unique ID of the creature.
        /// </summary>
        Guid ID { get; set; }

        /// <summary>
        /// Some attributes of the creature.
        /// </summary>
        CreatureAttributes Attributes { get; set; }

        /// <summary>
        /// All the equipped armor that the creature has.
        /// </summary>
        List<IArmor> Armoring { get; set; }

        /// <summary>
        /// All of the equipped rings that the creature has.
        /// </summary>
        List<IRing> Rings { get; set; }

        /// <summary>
        /// All of the equipped amulets that the creature has.
        /// </summary>
        List<IAmulet> Amulets { get; set; }

        /// <summary>
        /// The equipped weapons that the creature has.
        /// </summary>
        List<IWeapon> Weapons { get; set; }

        /// <summary>
        /// Called whenever the creature receives damage.
        /// </summary>
        /// <param name="damage"></param>
        void OnRecieveDamage(Damage damage);

        /// <summary>
        /// Called whenever the creature has a new item equipped.
        /// </summary>
        /// <param name="item"></param>
        void OnItemEquipped(IItem item);

        /// <summary>
        /// Called whenever the creature has a item unequipped.
        /// </summary>
        /// <param name="item"></param>
        void OnItemUnequipped(IItem item);

        /// <summary>
        /// Called whenever the creature is healed.
        /// </summary>
        /// <param name="healer">The creature that healed this creature.</param>
        void OnCreatureHealed(ICreature healer);

        /// <summary>
        /// Called whenever a creature dies.
        /// </summary>
        /// <param name="dead">The creature that is now dead.</param>
        void OnCreatureDied(ICreature dead);

        /// <summary>
        /// Called whenever this creature deals damage.
        /// </summary>
        void OnDealDamage();

        /// <summary>
        /// Raised whenever a creature takes damage.
        /// </summary>
        event EventHandler<Damage> TakeDamageEvent;

        /// <summary>
        /// Raised whenever a creature deals damage to another creature.
        /// </summary>
        event EventHandler<Damage> DealDamageEvent;

        /// <summary>
        /// Raised whenever a new item is equipped.
        /// </summary>
        event EventHandler<ICreature> ItemEquipped;

        /// <summary>
        /// Raised whenever a item is unequipped.
        /// </summary>
        event EventHandler<ICreature> ItemUnequipped;

        /// <summary>
        /// Raised whenever a creature dies.
        /// </summary>
        event EventHandler<ICreature> CreatureDied;

        /// <summary>
        /// Raised whenever a creature is healed.
        /// </summary>
        event EventHandler<ICreature> CreatureHealed;

    }
}
