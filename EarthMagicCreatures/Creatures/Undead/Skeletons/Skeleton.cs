using EarthWithMagicAPI.API.Creature;
using System;
using System.Collections.Generic;
using System.Text;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Interfaces.Items;

namespace EarthMagicCreatures.Creatures.Undead.Skeletons
{
    /// <summary>
    /// A undead but weak creature.
    /// </summary>
    public class Skeleton : ICreature
    {
        public Skeleton() : base()
        {
            
        }

        public override CreatureAttributes GetAttributes()
        {
            throw new NotImplementedException();
        }

        public override void OnCreatureDied(ICreature dead)
        {
            throw new NotImplementedException();
        }

        public override void OnCreatureHealed(ICreature healer)
        {
            throw new NotImplementedException();
        }

        public override void OnDealDamage()
        {
            throw new NotImplementedException();
        }

        public override void OnItemEquipped(IItem item)
        {
            throw new NotImplementedException();
        }

        public override void OnItemUnequipped(IItem item)
        {
            throw new NotImplementedException();
        }

        public override void OnRecieveDamage(Damage damage)
        {
            throw new NotImplementedException();
        }

        public override void YourTurn()
        {
            throw new NotImplementedException();
        }
    }
}
