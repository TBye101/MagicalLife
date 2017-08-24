// <copyright file="Encounter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Stuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EarthWithMagicAPI.API.Creature;

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
        /// The party's enemies.
        /// </summary>
        public List<ICreature> Enemies;

        /// <summary>
        /// The party.
        /// </summary>
        public List<ICreature> Party;

        public Encounter(List<ICreature> friendly, List<ICreature> enemies)
        {
            this.Party = friendly;
            this.Enemies = enemies;
            this.AllCombatants.AddRange(friendly);
            this.AllCombatants.AddRange(enemies);
            this.AllCombatants = this.AllCombatants.OrderByDescending(iCreature => iCreature.Attributes.BaseInitiative).ToList();
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
                    if (!this.IsEveryoneDead(this.Enemies) && !this.IsEveryoneDead(this.Party))
                    {
                        if (item.IsHostile())
                        {
                            int length = this.Enemies.Count;
                            for (int i = 0; i < length; i++)
                            {
                                ICreature iitem = this.Enemies[i];
                                if (iitem.ID == item.ID && item.Attributes.Health > 0)
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
                                if (iitem.ID == item.ID && item.Attributes.Health > 0)
                                {
                                    item.YourTurn(this);
                                    Util.Util.WriteLine("Hit any key to continue the fight to the next combatant....");
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
                }
                this.AwardXP();

                this.RemoveExpired(this.Enemies, this.Party, this.Enemies);
                this.RemoveExpired(this.Party, this.Party, this.Enemies);
            }

            return this.Party;
        }

        /// <summary>
        /// Awards XP to the party for each enemy killed.
        /// </summary>
        private void AwardXP()
        {
            if (this.IsEveryoneDead(this.Party))
            {
                Util.Util.WriteLine("Y'all are dead. Try again.");
            }
            else
            {
                int l = this.Party.Count;
                for (int i = 0; i < l; i++)
                {
                    //Gives xp for killing enemies.
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

                    this.Party[i].EncounterEnded(this);
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
                if (item.Attributes.Health > 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Removes expired spells an abilities that were effecting the creatures.
        /// </summary>
        /// <param name="party"></param>
        /// <param name="enemies"></param>
        /// <param name="creatures"></param>
        private void RemoveExpired(List<ICreature> creatures, List<ICreature> party, List<ICreature> enemies)
        {
            foreach (ICreature item in creatures)
            {
                //Remove spells that have expired. AKA an effect wore off.
                int length = item.SpellsAffectedBy.Count;
                for (int i = 0; i < length; i++)
                {
                    if (item.SpellsAffectedBy[i].RoundsLeft < 1)
                    {
                        item.SpellsAffectedBy[i].OnWearOff(party, enemies, item);
                        item.SpellsAffectedBy.RemoveAt(i);
                        i--;
                        length--;
                    }
                }

                //Remove abilities that have expired. AKA an effect wore off.
                length = item.AbilitiesAffectedBy.Count;
                for (int i = 0; i < length; i++)
                {
                    if (item.AbilitiesAffectedBy[i].RoundsLeft < 1)
                    {
                        item.AbilitiesAffectedBy[i].OnWearOff(party, enemies, item);
                        item.AbilitiesAffectedBy.RemoveAt(i);
                        i--;
                        length--;
                    }
                }
            }
        }
    }
}