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
            string[] Command = Input.Split(' ');
            while (Input != "end turn")
            {
                Input = Console.ReadLine().ToLower();

                switch (Input)
                {
                    case "help":
                        Help(creature, encounter, Command);
                        break;
                    case "view inventory":
                        ViewInventory(creature, encounter, Command);
                        break;
                    case "equip":
                        Equip(creature, encounter, Command);
                        break;
                    case "swing":
                        Swing(creature, encounter, Command);
                        break;
                    case "use ability":
                        UseAbility(creature, encounter, Command);
                        break;
                    case "list abilities":
                        ListAbilities(creature, encounter, Command);
                        break;
                    case "cast":
                        Cast(creature, encounter, Command);
                        break;
                    case "list spells":
                        ListSpells(creature, encounter, Command);
                        break;
                    case "use":
                        Use(creature, encounter, Command);
                        break;
                    case "list enemies":
                        ListEnemies(creature, encounter, Command);
                        break;
                    case "list party":
                        ListParty(creature, encounter, Command);
                        break;
                    case "summon":
                        Summon(creature, encounter, Command);
                        break;
                    case "list summons":
                        ListSummons(creature, encounter, Command);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ListAbilities(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void UseAbility(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void ListSpells(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void ListSummons(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void Summon(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void ListParty(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void ListEnemies(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void Use(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void Cast(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void Swing(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void Equip(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void ViewInventory(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Displays some help information.
        /// </summary>
        private static void Help(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }
    }
}