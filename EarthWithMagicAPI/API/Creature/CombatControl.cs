using System.Linq;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Util;
using EarthWithMagicAPI.API.Interfaces.Spells;
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
        /// <summary>
        /// If true, don't allow another action.
        /// </summary>
        public static bool TakenAction = false;

        public static void YourTurn(ICreature creature, Encounter encounter)
        {
            TakenAction = false;
            Util.Util.WriteLine("Combat for " + creature.Name + " initiated! Type 'help' for commands");
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
                        Equip(creature);
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
                    case "unequip":
                        Unequip(creature, encounter, Command);
                        break;
                    case "rotate":
                        Rotate(creature, encounter, Command);
                        break;
                    default:
                        break;
                }
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

        private static void ListAbilities(ICreature creature, Encounter encounter, string[] Command)
        {
            foreach (IAbility item in creature.ClassAbilities)
            {
                Util.Util.WriteLine(item.Name + " [" + item.AvailibleUses.ToString() + "]");
            }
        }

        private static void UseAbility(ICreature creature, Encounter encounter, string[] Command)
        {
            if (!TakenAction)
            {
                TakenAction = true;
                if (Command.Length < 2)
                {
                    Util.Util.WriteLine("Missing argument!");
                }
                else
                {
                    foreach (IAbility item in creature.ClassAbilities)
                    {
                        if (item.Name == Command[1])
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

        private static void ListSpells(ICreature creature, Encounter encounter, string[] Command)
        {
            foreach (ISpell item in creature.UsableSpells)
            {
                Util.Util.WriteLine(item.Name + ", " + item.PowerRequired.ToString());
            }
        }

        private static void ListParty(ICreature creature, Encounter encounter, string[] Command)
        {
            foreach (ICreature item in encounter.Party)
            {
                Util.Util.WriteLine(item.Name + " HP: [" + item.GetAttributes().Health.ToString() + "]");
            }
        }

        private static void ListEnemies(ICreature creature, Encounter encounter, string[] Command)
        {
            foreach (ICreature item in encounter.Enemies)
            {
                if (item.GetAttributes().Health > 0)
                {
                    Util.Util.WriteLine(item.Name + " HP: [" + item.GetAttributes().Health.ToString() + "]");
                }
            }
        }

        private static void Use(ICreature creature, Encounter encounter, string[] Command)
        {
            if (!TakenAction)
            {
                TakenAction = true;
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

        private static void Cast(ICreature creature, Encounter encounter, string[] Command)
        {
            if (!TakenAction)
            {
                TakenAction = true;
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
                                item.Go(encounter.Party, encounter.Enemies, creature);
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

        private static void Swing(ICreature creature, Encounter encounter, string[] Command)
        {
            if (!TakenAction)
            {
                TakenAction = true;
                if (creature.Weapons.Count > 0)
                {
                    foreach (IWeapon item in creature.Weapons)
                    {
                        item.Attack(encounter.Enemies[0]);
                    }
                }
                else
                {
                    creature.BareHands.Attack(encounter.Enemies[0]);
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
                    item.Equip();
                    Util.Util.WriteLine("Item equipped!");
                    return;
                }
            }

            Util.Util.WriteLine("Item not found!");
        }

        private static void ViewInventory(ICreature creature, Encounter encounter, string[] Command)
        {
            string Items = "";
            foreach (IItem item in creature.Amulets)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = "";
            foreach (IItem item in creature.Armoring)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = "";
            foreach (IItem item in creature.Inventory)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = "";
            foreach (IItem item in creature.Rings)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = "";
            foreach (IItem item in creature.Weapons)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
        }

        /// <summary>
        /// Displays some help information.
        /// </summary>
        private static void Help(ICreature creature, Encounter encounter, string[] Command)
        {
            Util.Util.WriteLine("help: displays help information");
            Util.Util.WriteLine("view inventory: displays the player's inventory");
            Util.Util.WriteLine("equip: equips an item, that you may choose in a bit");
            Util.Util.WriteLine("swing: Attacks the enemy at the front of the line via melee");
            Util.Util.WriteLine("use ability: Allows you to use an ability");
            Util.Util.WriteLine("list abilities: Spits out a list of available abilities to the current character");
            Util.Util.WriteLine("cast: Allows you to choose a spell to cast");
            Util.Util.WriteLine("list spells: Lists all of the spells available");
            Util.Util.WriteLine("use: Allows you to use a potion, or other item.");
            Util.Util.WriteLine("list enemies: Lists all the enemies still alive");
            Util.Util.WriteLine("list party: Lists all of the members of the party, including dead ones");
            Util.Util.WriteLine("unequip: Un-equips something");
            Util.Util.WriteLine("rotate: Rotates the person at the front of the party to the back.");
            Util.Util.WriteLine("end turn: Ends this round for the current creature");
        }
    }
}