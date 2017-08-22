namespace EarthWithMagicAPI.API.Controls
{
    using System;
    using System.Collections.Generic;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;

    public static class NonCombatControl
    {
        /// <summary>
        /// If true, don't allow another action.
        /// </summary>
        private static bool takenAction = false;

        public static void YourTurn(ICreature creature, Encounter encounter)
        {
            if (CanTakeTurn(creature, encounter))
            {
                takenAction = false;
                Util.Util.WriteLine("Combat for " + creature.Name + " initiated! Type 'help' for commands");
                string Input = string.Empty;
                string[] command;
                while (Input != "end turn")
                {
                    Input = Console.ReadLine().ToLower();
                    command = Input.Split(' ');

                    if (command[0] == "use" && command[1] == "ability")
                    {
                        UseAbility(creature, encounter, command);
                        continue;
                    }

                    if (command[0] == "cast")
                    {
                        Cast(creature, encounter, command);
                        continue;
                    }

                    if (command[0] == "use")
                    {
                        Use(creature, encounter, command);
                        continue;
                    }

                    if (command[0] == "view" && command[1] == "item")
                    {
                        ViewItem(creature, encounter, command);
                        continue;
                    }

                    switch (Input)
                    {
                        case "help":
                            Help(creature, encounter, command);
                            break;

                        case "view inventory":
                            ViewInventory(creature, encounter, command);
                            break;

                        case "equip":
                            Equip(creature);
                            break;

                        case "list abilities":
                            ListAbilities(creature, encounter, command);
                            break;

                        case "list spells":
                            ListSpells(creature, encounter, command);
                            break;

                        case "list party":
                            ListParty(creature, encounter, command);
                            break;

                        case "unequip":
                            Unequip(creature, encounter, command);
                            break;
                        case "rest":
                            Rest(encounter);
                            break;

                        case "rotate":
                            Rotate(creature, encounter, command);
                            break;
                        default:
                            Util.Util.WriteLine("Command not recognized!");
                            break;
                    }
                }
            }
        }

        private static void Rest(Encounter encounter)
        {
            foreach (ICreature item in encounter.Party)
            {
                item.Rest();
            }
        }

        private static void ViewItem(ICreature creature, Encounter encounter, string[] command)
        {
            if (command.Length < 3)
            {
                Util.Util.WriteLine("Missing argument(s)!");
                Util.Util.WriteLine("Third argument should be the name of the argument to view!");
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

        /// <summary>
        /// Determines if the creature gets to take a turn.
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="encounter"></param>
        /// <returns></returns>
        private static bool CanTakeTurn(ICreature creature, Encounter encounter)
        {
            foreach (IAbility item in creature.AbilitiesAffectedBy)
            {
                if (!item.OnTurn(encounter.Party, encounter.Enemies, creature))
                {
                    return false;
                }
            }

            foreach (ISpell item in creature.SpellsAffectedBy)
            {
                if (!item.OnTurn(encounter.Party, encounter.Enemies, creature))
                {
                    return false;
                }
            }

            return true;
        }

        private static void Cast(ICreature creature, Encounter encounter, string[] Command)
        {
            if (!takenAction)
            {
                takenAction = true;
                if (Command.Length > 1)
                {
                    foreach (ISpell item in creature.SpellsKnown)
                    {
                        if (item.Name == Command[1])
                        {
                            if (item.PowerRequired > creature.CastingPower)
                            {
                                Util.Util.WriteLine("Not enough casting power!");
                            }
                            else
                            {
                                creature.CastingPower -= item.PowerRequired;
                                item.Cast(encounter.Party, encounter.Enemies, creature);
                                Util.Util.WriteLine("Casting " + item.Name);
                                return;
                            }
                        }
                    }

                    Util.Util.WriteLine("Spell not found!");
                }
                else
                {
                    Util.Util.WriteLine("Missing argument!");
                }
            }
            else
            {
                Util.Util.WriteLine("Action already taken!");
            }
        }

        private static void Equip(ICreature creature)
        {
            Util.Util.WriteLine("Which item? (Specify by name)");
            string name = Console.ReadLine();
            foreach (IItem item in creature.Inventory)
            {
                if (item.Name == name)
                {
                    if (item.CanEquip(creature))
                    {
                        Util.Util.WriteLine("Item equipped!");
                    }
                    else
                    {
                        Util.Util.WriteLine("Failed to equip " + item.Name);
                    }
                    return;
                }
            }

            Util.Util.WriteLine("Item not found!");
        }

        /// <summary>
        /// Displays some help information.
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="encounter"></param>
        /// <param name="Command"></param>
        private static void Help(ICreature creature, Encounter encounter, string[] Command)
        {
            Util.Util.WriteLine("help: displays help information.");
            Util.Util.WriteLine("view inventory: displays the player's inventory.");
            Util.Util.WriteLine("equip: equips an item, that you may choose in a bit.");
            Util.Util.WriteLine("swing: Attacks the enemy at the front of the line via melee.");
            Util.Util.WriteLine("use ability: Allows you to use an ability.");
            Util.Util.WriteLine("list abilities: Spits out a list of available abilities to the current character.");
            Util.Util.WriteLine("cast: Allows you to choose a spell to cast.");
            Util.Util.WriteLine("list spells: Lists all of the spells available.");
            Util.Util.WriteLine("use: Allows you to use a potion, or other item.");
            Util.Util.WriteLine("list enemies: Lists all the enemies still alive.");
            Util.Util.WriteLine("list party: Lists all of the members of the party, including dead ones.");
            Util.Util.WriteLine("unequip: Un-equips something.");
            Util.Util.WriteLine("rotate: Rotates the person at the front of the party to the back.");
            Util.Util.WriteLine("end turn: Ends this round for the current creature.");
            Util.Util.WriteLine("view item: Views the specified items image and information.");
        }

        private static void ListAbilities(ICreature creature, Encounter encounter, string[] Command)
        {
            foreach (IAbility item in creature.ClassAbilities)
            {
                Util.Util.WriteLine(item.Name + " [" + item.AvailibleUses.ToString() + "]");
            }
        }

        private static void ListParty(ICreature creature, Encounter encounter, string[] Command)
        {
            foreach (ICreature item in encounter.Party)
            {
                Util.Util.WriteLine(item.Name + " HP: [" + item.Attributes.Health.ToString() + "]");
            }
        }

        private static void ListSpells(ICreature creature, Encounter encounter, string[] Command)
        {
            foreach (ISpell item in creature.UsableSpells)
            {
                Util.Util.WriteLine(item.Name + ", " + item.PowerRequired.ToString());
            }
        }

        private static void Rotate(ICreature creature, Encounter encounter, string[] Command)
        {
            ICreature Front = encounter.Party[0];
            encounter.Party.RemoveAt(0);
            encounter.Party.Add(Front);
        }

        private static void Unequip(ICreature creature, Encounter encounter, string[] Command)
        {
            Util.Util.WriteLine("Unequip what?");
            string name = Console.ReadLine();

            foreach (IItem item in creature.Amulets)
            {
                if (item.Name == name)
                {
                    item.Unequip();
                    Util.Util.WriteLine("Item unequipped!");
                    return;
                }
            }

            foreach (IItem item in creature.Armoring)
            {
                if (item.Name == name)
                {
                    item.Unequip();
                    Util.Util.WriteLine("Item unequipped!");
                    return;
                }
            }

            foreach (IItem item in creature.Rings)
            {
                if (item.Name == name)
                {
                    item.Unequip();
                    Util.Util.WriteLine("Item unequipped!");
                    return;
                }
            }

            foreach (IItem item in creature.Weapons)
            {
                if (item.Name == name)
                {
                    item.Unequip();
                    Util.Util.WriteLine("Item unequipped!");
                    return;
                }
            }

            Util.Util.WriteLine("Item not found!");
        }

        private static void Use(ICreature creature, Encounter encounter, string[] Command)
        {
            if (!takenAction)
            {
                takenAction = true;
                if (Command.Length < 2)
                {
                    Util.Util.WriteLine("Missing argument!");
                }
                else
                {
                    List<IItem> Items = new List<IItem>();
                    Items.AddRange(creature.Amulets);
                    Items.AddRange(creature.Armoring);
                    Items.AddRange(creature.Inventory);
                    Items.AddRange(creature.Rings);
                    Items.AddRange(creature.Weapons);

                    foreach (IItem item in Items)
                    {
                        if (item.Name == Command[1])
                        {
                            Util.Util.WriteLine("Using " + item.Name);
                            item.Use();
                            return;
                        }
                    }

                    Util.Util.WriteLine("Item not found!");
                }
            }
            else
            {
                Util.Util.WriteLine("Action already taken!");
            }
        }

        private static void UseAbility(ICreature creature, Encounter encounter, string[] Command)
        {
            if (!takenAction)
            {
                takenAction = true;
                if (Command.Length < 3)
                {
                    Util.Util.WriteLine("Missing argument!");
                    Util.Util.WriteLine("3rd argument should be the name of the ability to use!");
                }
                else
                {
                    foreach (IAbility item in creature.ClassAbilities)
                    {
                        if (item.Name == Command[2])
                        {
                            if (item.AvailibleUses > 0)
                            {
                                item.Go(encounter.Party, encounter.Enemies, creature);
                            }
                            else
                            {
                                Util.Util.WriteLine("Ability has been used up!");
                            }

                            return;
                        }
                    }

                    Util.Util.WriteLine("Ability not found!");
                }
            }
            else
            {
                Util.Util.WriteLine("Action already taken!");
            }
        }

        private static void ViewInventory(ICreature creature, Encounter encounter, string[] Command)
        {
            string Items = string.Empty;
            foreach (IItem item in creature.Amulets)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = string.Empty;
            foreach (IItem item in creature.Armoring)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = string.Empty;
            foreach (IItem item in creature.Inventory)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = string.Empty;
            foreach (IItem item in creature.Rings)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = string.Empty;
            foreach (IItem item in creature.Weapons)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
        }
    }
}