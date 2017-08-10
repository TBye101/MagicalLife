using System.Linq;
using EarthWithMagicAPI.API.Creature;
using System;
using System.Collections.Generic;
using System.Text;

using EarthWithMagicAPI.API.Util;

namespace EarthWithMagicAPI.API.Stuff
{
    /// <summary>
    /// Used whenever a fight occurs.
    /// </summary>
    public class Encounter
    {
        /// <summary>
        /// A list of all the combatants sorted by initiative.
        /// </summary>
        private List<ICreature> AllCombatants = new List<ICreature>();

        public Encounter(List<ICreature> friendly, List<ICreature> enemies)
        {
            this.AllCombatants.AddRange(friendly);
            this.AllCombatants.AddRange(enemies);
            this.AllCombatants = this.AllCombatants.OrderByDescending(ICreature => ICreature.GetAttributes().BaseInitiative).ToList();

            while (!IsEveryoneDead(friendly) && !IsEveryoneDead(enemies))
            {
                Console.WriteLine("Encounter: " + friendly.Count.ToString() + " friendlies, " + enemies.Count.ToString() + " enemies");

                foreach (ICreature item in this.AllCombatants)
                {
                    item.YourTurn(this);
                    Util.Util.WriteLine("Hit any key to continue the fight to the next combatant....");
                }
            }
        }

        /// <summary>
        /// Determines if everyone on one side is dead yet.
        /// </summary>
        /// <param name="creatures"></param>
        /// <returns></returns>
        private bool IsEveryoneDead(List<ICreature> creatures)
        {
            foreach (ICreature item in creatures)
            {
                if (item.GetAttributes().Health > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
