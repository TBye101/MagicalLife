using EarthWithMagicAPI.API.Creature;
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