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
                Util.Util.WriteLine("Encounter: " + this.Party.Count.ToString() + " friendly, " + this.Enemies.Count.ToString() + " enemies");

                foreach (ICreature item in this.AllCombatants)
                {
                    if (!this.IsEveryoneDead(this.Enemies) && !this.IsEveryoneDead(Party))
                    {
                        if (item.IsHostile())
                        {
                            int length = this.Enemies.Count;
                            for (int i = 0; i < length; i++)
                            {
                                ICreature iitem = this.Enemies[i];
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
                            int length = this.Party.Count;
                            for (int i = 0; i < length; i++)
                            {
                                ICreature iitem = this.Party[i];
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

            if (this.IsEveryoneDead(this.Party))
            {
                Util.Util.WriteLine("Y'all are dead. Try again.");
            }
            else
            {

                int l = this.Party.Count;
                for (int i = 0; i < l; i++)
                {
                    foreach (ICreature item in this.Enemies)
                    {
                        int TotalGained = 0;
                        //If dead
                        if (item.Attributes.Health < 1)
                        {
                            this.Party[i].Attributes.XP.RecieveXP(item.XPValue());
                            TotalGained += item.XPValue();
                        }

                        Util.Util.WriteLine(this.Party[i].Name + " gained " + TotalGained.ToString() + " xp");
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
