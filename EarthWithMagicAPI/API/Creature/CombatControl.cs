using EarthWithMagicAPI.API.Stuff;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Gives the player options for each creature in their party in combat.
    /// </summary>
    public static class CombatControl
    {
        public static void YourTurn(ICreature creature, Encounter encounter)
        {
            string Input = "";
            while (Input != "end turn")
            {
                Input = Console.ReadLine().ToLower();

                switch (Input)
                {
                    case "help":
                        Help(creature, encounter);
                        break;
                    case "view inventory":
                        ViewInventory(creature, encounter);
                        break;
                    case "equip":
                        Equip(creature, encounter);
                        break;
                    case "swing":
                        Swing(creature, encounter);
                        break;
                    case "cast":
                        Cast(creature, encounter);
                        break;
                    case "use":
                        Use(creature, encounter);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void Use(ICreature creature, Encounter encounter)
        {
            throw new NotImplementedException();
        }

        private static void Cast(ICreature creature, Encounter encounter)
        {
            throw new NotImplementedException();
        }

        private static void Swing(ICreature creature, Encounter encounter)
        {
            throw new NotImplementedException();
        }

        private static void Equip(ICreature creature, Encounter encounter)
        {
            throw new NotImplementedException();
        }

        private static void ViewInventory(ICreature creature, Encounter encounter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Displays some help information.
        /// </summary>
        private static void Help(ICreature creature, Encounter encounter)
        {
            throw new NotImplementedException();
        }
    }
}