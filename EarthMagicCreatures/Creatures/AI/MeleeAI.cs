namespace EarthMagicCreatures.Creatures.AI
{
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Stuff;

    /// <summary>
    /// Does melee for melee only creatures.
    /// </summary>
    public class MeleeAI : IAI
    {
        public void YourTurn(Encounter encounter, ICreature creature)
        {
            if (creature.IsHostile())
            {
                if (creature.Weapons.Count > 0)
                {
                    creature.Weapons[0].Attack(encounter.Party[0]);
                }
                else
                {
                    creature.BareHands.Attack(encounter.Party[0]);
                }
            }
            else
            {
                if (creature.Weapons.Count > 0)
                {
                    creature.Weapons[0].Attack(encounter.Enemies[0]);
                }
                else
                {
                    creature.BareHands.Attack(encounter.Enemies[0]);
                }
            }
        }
    }
}