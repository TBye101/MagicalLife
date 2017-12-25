// <copyright file="Skeleton.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicCreatures.Creatures.Undead.Skeletons
{
    using System;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;

    /// <summary>
    /// A undead but weak creature.
    /// </summary>
    public class Skeleton : ICreature
    {
        public Skeleton(CreatureAttributes attributes, CreatureAbilities abilities)
            : base(attributes, abilities, null, null, null)
        {
        }

        public override bool IsHostile()
        {
            return true;
        }

        public override void OnCreatureDied(ICreature dead)
        {
        }

        public override void OnCreatureHealed(ICreature healer)
        {
        }

        public override void OnDealDamage()
        {
        }

        public override void OnItemUnequipped(IItem item)
        {
        }
    }
}