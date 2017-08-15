using System.Linq;
using EarthMagicCharacters.Classes.Monk.Generic_Monk;
using EarthWithMagicAPI.API.Creature;
using System;
using System.Collections.Generic;
using System.Text;
using EarthWithMagicAPI.API.Stuff;

namespace EarthMagicCharacters.Classes.Monk
{
    /// <summary>
    /// The AI for a monk.
    /// </summary>
    public class MonkAI : IAI
    {
        public void YourTurn(Encounter encounter, ICreature monk)
        {
            monk.BareHands.Attack(encounter.Party[0]);
        }
    }
}
