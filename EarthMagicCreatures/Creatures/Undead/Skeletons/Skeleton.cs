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
        /// <summary>
        /// The attributes of this skeleton.
        /// </summary>
        private CreatureAttributes Attributes = new CreatureAttributes(Gender.Unspecified, 7, 10, 10, 10, 14, 13, -1, 8, 0, 0, 100, 0, 100, 0, 0, 100, false, 10, 30, 15);

        public Skeleton() : base()
        {
        }

        public override void EncounterEnded(Encounter fight)
        {
            throw new NotImplementedException();
        }

        public override void EquipItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public override CreatureAttributes GetAttributes()
        {
            return this.Attributes;
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

        public override void RecieveDamage(Damage damage)
        {
            throw new NotImplementedException();
        }

        public override void YourTurn(Encounter encounter)
        {
            throw new NotImplementedException();
        }
    }
}
