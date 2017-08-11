using Microsoft.VisualBasic.CompilerServices;
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
        public List<ICreature> AllCombatants = new List<ICreature>();

        /// <summary>
        /// The party.
        /// </summary>
        public List<ICreature> Party;

        /// <summary>
        /// The party's enemies.
        /// </summary>
        public List<ICreature> Enemies;

        public Encounter(List<ICreature> friendly, List<ICreature> enemies)
        {
            this.Party = friendly;
            this.Enemies = enemies;
            this.AllCombatants.AddRange(friendly);
            this.AllCombatants.AddRange(enemies);
            this.AllCombatants = this.AllCombatants.OrderByDescending(ICreature => ICreature.GetAttributes().BaseInitiative).ToList();
        }

        /// <summary>
        /// Returns the party after the fight.
        /// </summary>
        /// <returns></returns>
        public List<ICreature> Fight()
        {
            while (!IsEveryoneDead(this.Party) && !IsEveryoneDead(this.Enemies))
            {
                Util.Util.WriteLine("Encounter: " + this.Party.Count.ToString() + " friendlies, " + this.Enemies.Count.ToString() + " enemies");

                foreach (ICreature item in this.AllCombatants)
                {
                    if (!this.IsEveryoneDead(this.Enemies) && !this.IsEveryoneDead(Party))
                    {
                        if (item.IsHostile())
                        {
                            foreach (ICreature iitem in this.Enemies)
                            {
                                if (iitem.ID == item.ID && item.GetAttributes().Health > 0)
                                {
                                    item.YourTurn(this);
                                    Util.Util.WriteLine("Hit any key to continue the fight to the next combatant....");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            foreach (ICreature iitem in this.Party)
                            {
                                if (iitem.ID == item.ID && item.GetAttributes().Health > 0)
                                {
                                    item.YourTurn(this);
                                    Util.Util.WriteLine("Hit any key to continue the fight to the next combatant....");
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
                }
            }

            return this.Party;
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
