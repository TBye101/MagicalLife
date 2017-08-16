using EarthWithMagicAPI.API.Creature;
using System;
using System.Collections.Generic;
using System.Text;
using EarthWithMagicAPI.API.Stuff;

namespace EarthMagicCharacters.Classes.Thief.Generic_Thief
{
    public class ThiefAI : IAI
    {
        public void YourTurn(Encounter encounter, ICreature creature)
        {
            if (creature.Weapons.Count < 1)
            {
                creature.BareHands.Attack(encounter.Party[0]);
            }
            else
            {
                creature.Weapons[0].Attack(encounter.Party[0]);
            }
        }
    }
}
