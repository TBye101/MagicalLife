using EarthMagicCharacters.Classes;
// <copyright file="NonCombatControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Controls
{
    using System;
    using System.Collections.Generic;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Party;
    using EarthWithMagicAPI.API.Util;

    public static class NonCombatControl
    {
        /// <summary>
        /// If true, don't allow another action.
        /// </summary>
        private static bool takenAction = false;

        public static void YourTurn(ICreature creature)
        {
            if (CanTakeTurn(creature))
            {
                takenAction = false;
                Util.WriteLine("Combat for " + creature.Name + " initiated! Type 'help' for commands");
                string input = string.Empty;
                string[] command;
                while (input != "end turn")
                {
                    input = Console.ReadLine().ToLower();
                    command = input.Split(' ');

                    if (command[0] == "use" && command[1] == "ability")
                    {
                        UseAbility(creature, command);
                        continue;
                    }

                    if (command[0] == "cast")
                    {
                        Cast(creature, command);
                        continue;
                    }

                    if (command[0] == "use")
                    {
                        Use(creature, command);
                        continue;
                    }

                    if (command[0] == "view" && command[1] == "item")
                    {
                        ViewItem(creature, command);
                        continue;
                    }

                    if (command[0] == "pray")
                    {
                        Pray(creature, command);
                    }

                    switch (input)
                    {
                        case "help":
                            Help();
                            break;

                        case "view inventory":
                            ViewInventory(creature);
                            break;

                        case "equip":
                            Equip(creature);
                            break;

                        case "list abilities":
                            ListAbilities(creature);
                            break;

                        case "list spells":
                            ListSpells(creature);
                            break;

                        case "list party":
                            ListParty();
                            break;

                        case "unequip":
                            Unequip(creature);
                            break;

                        case "rest":
                            Rest();
                            break;

                        case "rotate":
                            Rotate();
                            break;
                        case "list prayers":
                            ListPrayers(creature);
                            break;
                        case "level up":
                            LevelUp(creature);
                            break;
                        default:
                            Util.WriteLine("Command not recognized!");
                            break;
                    }
                }
            }
        }

        private static void LevelUp(ICreature creature)
        {
            if (creature is ICharacter)
            {
                ICharacter character = (ICharacter)creature;
                character.LevelUp();
                Util.WriteLine("Leveling up " + character.Name);
            }
            else
            {
                Util.WriteLine(creature.Name + " cannot be leveled up!");
            }
        }

        private static void Pray(ICreature creature, string[] command)
        {
            if (!takenAction)
            {
                if (command.Length >= command.Length)
                {
                    foreach (IPrayer item in creature.PrayersKnown)
                    {
                        if (string.Equals(item.Name, command[1], StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (item.Pray(Party.TheParty, creature))
                            {
                                takenAction = true;
                                return;
                            }
                        }
                    }

                    Util.WriteLine("Prayer not found!");
                }
                else
                {
                    Util.WriteLine("Missing argument!");
                }
            }
            else
            {
                Util.WriteLine(creature.Name + " has already used it's action!");
            }
        }

        private static void ListPrayers(ICreature creature)
        {
            foreach (IPrayer item in creature.PrayersKnown)
            {
                Util.WriteLine(item.Name);
            }
        }

        /// <summary>
        /// Determines if the creature gets to take a turn.
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="encounter"></param>
        /// <returns></returns>
        private static bool CanTakeTurn(ICreature creature)
        {
            foreach (IAbility item in creature.AbilitiesAffectedBy)
            {
                if (!item.OnTurn(Party.TheParty, creature))
                {
                    return false;
                }
            }

            foreach (ISpell item in creature.SpellsAffectedBy)
            {
                if (!item.OnTurn(Party.TheParty, creature))
                {
                    return false;
                }
            }

            return true;
        }

        private static void Cast(ICreature creature, string[] command)
        {
            if (!takenAction)
            {
                takenAction = true;
                if (command.Length > 1)
                {
                    foreach (ISpell item in creature.SpellsKnown)
                    {
                        if (item.Name == command[1])
                        {
                            if (item.PowerRequired > creature.CastingPower)
                            {
                                Util.WriteLine("Not enough casting power!");
                            }
                            else
                            {
                                creature.CastingPower -= item.PowerRequired;
                                item.Cast(Party.TheParty, creature);
                                Util.WriteLine("Casting " + item.Name);
                                return;
                            }
                        }
                    }

                    Util.WriteLine("Spell not found!");
                }
                else
                {
                    Util.WriteLine("Missing argument!");
                }
            }
            else
            {
                Util.WriteLine("Action already taken!");
            }
        }

        private static void Equip(ICreature creature)
        {
            Util.WriteLine("Which item? (Specify by name)");
            string name = Console.ReadLine();
            foreach (IItem item in creature.Inventory)
            {
                if (item.Name == name)
                {
                    if (item.CanEquip(creature))
                    {
                        Util.WriteLine("Item equipped!");
                    }
                    else
                    {
                        Util.WriteLine("Failed to equip " + item.Name);
                    }

                    return;
                }
            }

            Util.WriteLine("Item not found!");
        }

        /// <summary>
        /// Displays some help information.
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="encounter"></param>
        /// <param name="Command"></param>
        private static void Help()
        {
            Util.WriteLine("help: displays help information.");
            Util.WriteLine("view inventory: displays the player's inventory.");
            Util.WriteLine("equip: equips an item, that you may choose in a bit.");
            Util.WriteLine("swing: Attacks the enemy at the front of the line via melee.");
            Util.WriteLine("use ability: Allows you to use an ability.");
            Util.WriteLine("list abilities: Spits out a list of available abilities to the current character.");
            Util.WriteLine("cast: Allows you to choose a spell to cast.");
            Util.WriteLine("list spells: Lists all of the spells available.");
            Util.WriteLine("use: Allows you to use a potion, or other item.");
            Util.WriteLine("rest: Has the party try and rest.");
            Util.WriteLine("list party: Lists all of the members of the party, including dead ones.");
            Util.WriteLine("unequip: Un-equips something.");
            Util.WriteLine("rotate: Rotates the person at the front of the party to the back.");
            Util.WriteLine("end turn: Ends this round for the current creature.");
            Util.WriteLine("view item: Views the specified items image and information.");
            Util.WriteLine("list prayers: Displays all known prayers to the creature.");
            Util.WriteLine("pray: attempts to pray the specified prayer");
        }

        private static void ListAbilities(ICreature creature)
        {
            foreach (IAbility item in creature.ClassAbilities)
            {
                Util.WriteLine(item.Name + " [" + item.AvailibleUses.ToString() + "]");
            }
        }

        private static void ListParty()
        {
            foreach (ICreature item in Party.TheParty)
            {
                Util.WriteLine(item.Name + " HP: [" + item.Attributes.Health.ToString() + "]");
            }
        }

        private static void ListSpells(ICreature creature)
        {
            foreach (ISpell item in creature.UsableSpells)
            {
                Util.WriteLine(item.Name + ", " + item.PowerRequired.ToString());
            }
        }

        private static void Rest()
        {
            foreach (ICreature item in Party.TheParty)
            {
                item.Rest();
            }
        }

        private static void Rotate()
        {
            ICreature front = Party.TheParty[0];
            Party.TheParty.RemoveAt(0);
            Party.TheParty.Add(front);
        }

        private static void Unequip(ICreature creature)
        {
            Util.WriteLine("Unequip what?");
            string name = Console.ReadLine();

            foreach (IItem item in creature.Amulets)
            {
                if (item.Name == name)
                {
                    item.Unequip();
                    Util.WriteLine("Item unequipped!");
                    return;
                }
            }

            foreach (IItem item in creature.Armoring)
            {
                if (item.Name == name)
                {
                    item.Unequip();
                    Util.WriteLine("Item unequipped!");
                    return;
                }
            }

            foreach (IItem item in creature.Rings)
            {
                if (item.Name == name)
                {
                    item.Unequip();
                    Util.WriteLine("Item unequipped!");
                    return;
                }
            }

            foreach (IItem item in creature.Weapons)
            {
                if (item.Name == name)
                {
                    item.Unequip();
                    Util.WriteLine("Item unequipped!");
                    return;
                }
            }

            Util.WriteLine("Item not found!");
        }

        private static void Use(ICreature creature, string[] command)
        {
            if (!takenAction)
            {
                takenAction = true;
                if (command.Length < 2)
                {
                    Util.WriteLine("Missing argument!");
                }
                else
                {
                    List<IItem> items = new List<IItem>();
                    items.AddRange(creature.Amulets);
                    items.AddRange(creature.Armoring);
                    items.AddRange(creature.Inventory);
                    items.AddRange(creature.Rings);
                    items.AddRange(creature.Weapons);

                    foreach (IItem item in items)
                    {
                        if (item.Name == command[1])
                        {
                            Util.WriteLine("Using " + item.Name);
                            item.Use(creature);
                            return;
                        }
                    }

                    Util.WriteLine("Item not found!");
                }
            }
            else
            {
                Util.WriteLine("Action already taken!");
            }
        }

        private static void UseAbility(ICreature creature, string[] command)
        {
            if (!takenAction)
            {
                takenAction = true;
                if (command.Length < 3)
                {
                    Util.WriteLine("Missing argument!");
                    Util.WriteLine("3rd argument should be the name of the ability to use!");
                }
                else
                {
                    foreach (IAbility item in creature.ClassAbilities)
                    {
                        if (item.Name == command[2])
                        {
                            if (item.AvailibleUses > 0)
                            {
                                item.Use(Party.TheParty, creature);
                            }
                            else
                            {
                                Util.WriteLine("Ability has been used up!");
                            }

                            return;
                        }
                    }

                    Util.WriteLine("Ability not found!");
                }
            }
            else
            {
                Util.WriteLine("Action already taken!");
            }
        }

        private static void ViewInventory(ICreature creature)
        {
            string items = string.Empty;
            foreach (IItem item in creature.Amulets)
            {
                items += item.Name;
                items += ", ";
            }

            Util.WriteLine(items);
            items = string.Empty;
            foreach (IItem item in creature.Armoring)
            {
                items += item.Name;
                items += ", ";
            }

            Util.WriteLine(items);
            items = string.Empty;
            foreach (IItem item in creature.Inventory)
            {
                items += item.Name;
                items += ", ";
            }

            Util.WriteLine(items);
            items = string.Empty;
            foreach (IItem item in creature.Rings)
            {
                items += item.Name;
                items += ", ";
            }

            Util.WriteLine(items);
            items = string.Empty;
            foreach (IItem item in creature.Weapons)
            {
                items += item.Name;
                items += ", ";
            }

            Util.WriteLine(items);
        }

        private static void ViewItem(ICreature creature, string[] command)
        {
            if (command.Length < 3)
            {
                Util.WriteLine("Missing argument(s)!");
                Util.WriteLine("Third argument should be the name of the argument to view!");
            }
            else
            {
                foreach (IItem item in ICreature.GetAllItems(creature))
                {
                    if (item.Name == command[2])
                    {
                        item.DisplayImage();
                        item.DisplayDocumentation();
                        return;
                    }
                }
            }
        }
    }
}