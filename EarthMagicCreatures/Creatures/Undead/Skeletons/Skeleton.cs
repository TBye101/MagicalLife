using EarthWithMagicAPI.API.Stuff;
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
        CreatureAttributes Attributes = new CreatureAttributes(-1, 7, 10, 10, 10, 14, 13, -1, 8, new XP(1), 0, 0, 100, 0, 100, 0, 0, 100, false, 10);

        public Skeleton() : base()
        {
            
        }

        public override CreatureAttributes GetAttributes()
        {
            return this.Attributes;
        }

        public override bool IsHostile()
        {
            throw new NotImplementedException();
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

        public override void OnItemEquipped(IItem item)
        {

        }

        public override void OnItemUnequipped(IItem item)
        {

        }

        public override void OnRecieveDamage(Damage damage)
        {
            throw new NotImplementedException();
        }

        public override void YourTurn(Encounter encounter)
        {
            throw new NotImplementedException();
        }
    }
}
