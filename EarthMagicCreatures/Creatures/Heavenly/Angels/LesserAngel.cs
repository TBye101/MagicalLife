using EarthWithMagicAPI.API.Creature;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Stuff;
using System;

namespace EarthMagicCreatures.Creatures.Heavenly.Angels
{
    public class LesserAngel : ICreature
    {
        public override void EquipItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public override CreatureAttributes GetAttributes()
        {
            throw new NotImplementedException();
        }

        public override bool IsHostile()
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

        public override void OnItemUnequipped(IItem item)
        {
            throw new NotImplementedException();
        }

        public override void YourTurn(Encounter encounter)
        {
            throw new NotImplementedException();
        }
    }
}