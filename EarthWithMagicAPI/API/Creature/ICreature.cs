namespace EarthWithMagicAPI.API.Creature
{
    using System;
    using System.Collections.Generic;
    using EarthMagicCharacters.Classes;
    using EarthMagicDocumentation;
    using EarthWithMagicAPI.API.Controls;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Story;
    using EarthWithMagicAPI.API.Stuff;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// Holds various things that every creature has or should implement.
    /// </summary>
    public abstract class ICreature
    {
        /// <summary>
        /// The abilities of the creature.
        /// </summary>
        public CreatureAbilities Abilities = new CreatureAbilities();

        /// <summary>
        /// A list of abilities currently affecting this creature.
        /// </summary>
        public List<IAbility> AbilitiesAffectedBy = new List<IAbility>();

        /// <summary>
        /// All of the equipped amulets that the creature has.
        /// </summary>
        public List<IAmulet> Amulets = new List<IAmulet>();

        /// <summary>
        /// All the equipped armor that the creature has.
        /// </summary>
        public List<IArmor> Armoring = new List<IArmor>();

        /// <summary>
        /// The attributes for this creature.
        /// </summary>
        public CreatureAttributes Attributes;

        /// <summary>
        /// The fists of the creature. Mainly used in combat by monks.
        /// </summary>
        public Fists BareHands = new Fists();

        /// <summary>
        /// The amount of casting power the creature currently has.
        /// </summary>
        public int CastingPower = 0;

        /// <summary>
        /// A list of abilities the creature has.
        /// </summary>
        public List<IAbility> ClassAbilities = new List<IAbility>();

        /// <summary>
        /// The name of the type of creature the creature is.
        /// </summary>
        public CreatureType creatureType;

        /// <summary>
        /// The unique ID of the creature.
        /// </summary>
        public Guid ID = new Guid();

        /// <summary>
        /// All items on a creature that are not equipped go here.
        /// </summary>
        public List<IItem> Inventory = new List<IItem>();

        /// <summary>
        /// If true, the creature is part of the player's party.
        /// </summary>
        public bool IsInParty = false;

        /// <summary>
        /// Determines if the creature is mortal or not.
        /// </summary>
        public bool IsMortal = true;

        /// <summary>
        /// The amount of casting power the creature has after resting.
        /// </summary>
        public int MaxCastingPower = 0;

        /// <summary>
        /// The creature's name, if it has one.
        /// </summary>
        public string Name;

        /// <summary>
        /// All of the equipped rings that the creature has.
        /// </summary>
        public List<IRing> Rings = new List<IRing>();

        /// <summary>
        /// A list of spells currently affecting this creature.
        /// </summary>
        public List<ISpell> SpellsAffectedBy = new List<ISpell>();

        /// <summary>
        /// A list of all spells known to the creature.
        /// </summary>
        public List<ISpell> SpellsKnown = new List<ISpell>();

        /// <summary>
        /// The title of the creature, if any.
        /// </summary>
        public string Title;

        /// <summary>
        /// A list of the spells that this creature can actually use right now.
        /// </summary>
        public List<ISpell> UsableSpells = new List<ISpell>();

        /// <summary>
        /// The equipped weapons that the creature has.
        /// </summary>
        public List<IWeapon> Weapons = new List<IWeapon>();

        /// <summary>
        /// The amount of weight the creature can hold.
        /// </summary>
        public int WeightCapacity;

        /// <summary>
        /// The path to the documentation about this creature.
        /// </summary>
        private string DocumentationPath;

        /// <summary>
        /// The path to the image representing this type of creature.
        /// </summary>
        private string ImagePath;

        public IAI myAI;

        /// <summary>
        /// The constructor for the ICreature abstract class.
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="race"></param>
        /// <param name="alignment"></param>
        /// <param name="attributes"></param>
        /// <param name="abilities"></param>
        /// <param name="documentationPath"></param>
        /// <param name="imagePath"></param>
        protected ICreature(CreatureAttributes attributes, CreatureAbilities abilities, string documentationPath, string imagePath, IAI AI)
        {
            this.Attributes = attributes;
            this.Abilities = abilities;
            this.DocumentationPath = documentationPath;
            this.ImagePath = imagePath;
            this.Rest();
            this.WeightCapacity = WeightCapacityUtil.Calculate(this);
            this.myAI = AI;
        }

        /// <summary>
        /// Displays the image representing this creature.
        /// </summary>
        public void DisplayImage()
        {
            Util.WriteLine(ResourceGM.GetResource(this.ImagePath));
        }

        /// <summary>
        /// Displays the information about this creature.
        /// </summary>
        public void DisplayInformation()
        {
            Util.WriteLine(ResourceGM.GetResource(this.DocumentationPath));
        }

        /// <summary>
        /// Called whenever an encounter ends, so summoned creatures can be un-summoned.
        /// </summary>
        /// <param name="fight"></param>
        public void EncounterEnded(Encounter fight)
        {
            //Checks to see if this is a character that can level up.
            if (this.Attributes.XP.LevelUpsAvailible > 0 && this.GetType() == typeof(ICharacter))
            {
                ICharacter dis = (ICharacter)this;
                dis.LevelUp();
            }
        }

        /// <summary>
        /// Called whenever the creature has a new item equipped.
        /// </summary>
        /// <param name="item"></param>
        public abstract void EquipItem(IItem item);

        public string HeSheIT()
        {
            if (this.Attributes.Gender == Gender.Male)
            {
                return "Him";
            }

            if (this.Attributes.Gender == Gender.Female)
            {
                return "She";
            }
            else
            {
                return "It";
            }
        }

        /// <summary>
        /// Determines based on gender if we should be referring to this creature as a him/her/it.
        /// </summary>
        /// <returns></returns>
        public string HimHerIT()
        {
            if (this.Attributes.Gender == Gender.Male)
            {
                return "him";
            }

            if (this.Attributes.Gender == Gender.Female)
            {
                return "her";
            }

            if (this.Attributes.Gender == Gender.Unspecified)
            {
                return "IT";
            }

            return "IT";
        }

        /// <summary>
        /// Returns if the creature is hostile to the player.
        /// </summary>
        /// <returns></returns>
        public abstract bool IsHostile();

        /// <summary>
        /// Called whenever a creature dies.
        /// </summary>
        /// <param name="dead">The creature that is now dead.</param>
        public abstract void OnCreatureDied(ICreature dead);

        /// <summary>
        /// Called whenever the creature is healed.
        /// </summary>
        /// <param name="healer">The creature that healed this creature.</param>
        public abstract void OnCreatureHealed(ICreature healer);

        /// <summary>
        /// Called whenever this creature deals damage.
        /// </summary>
        public abstract void OnDealDamage();

        /// <summary>
        /// Called whenever the creature has a item unequipped.
        /// </summary>
        /// <param name="item"></param>
        public abstract void OnItemUnequipped(IItem item);

        /// <summary>
        /// Called whenever the creature receives damage.
        /// </summary>
        /// <param name="damage"></param>
        public void RecieveDamage(Damage damage)
        {
            if (this.IsInParty)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Util.WriteLine(this.Name + " is taking damage!");
            double dodgeChance = this.Attributes.Dodge / 2;

            if (Dice.RollDice(new Die(1, 100, 0), "Chance to not dodge") > dodgeChance)
            {
                //Don't dodge
                Util.WriteLine(this.Name + " failed to dodge the attack");

                if (damage.AcidDamage.Rolls > 0)
                {
                    this.Attributes.Health -= this.TakeDamage(damage.AcidDamage, "acid damage", this.Attributes.AcidResistance);
                }

                if (damage.BluntDamage.Rolls > 0)
                {
                    this.Attributes.Health -= this.TakeDamage(damage.BluntDamage, "blunt damage", this.Attributes.AC);
                }

                if (damage.ColdDamage.Rolls > 0)
                {
                    this.Attributes.Health -= this.TakeDamage(damage.ColdDamage, "cold damage", this.Attributes.ColdResistance);
                }

                if (damage.ElectricDamage.Rolls > 0)
                {
                    this.Attributes.Health -= this.TakeDamage(damage.ElectricDamage, "electric damage", this.Attributes.ElectricResistance);
                }

                if (damage.FireDamage.Rolls > 0)
                {
                    this.Attributes.Health -= this.TakeDamage(damage.FireDamage, "fire damage", this.Attributes.FireResistance);
                }

                if (damage.MagicDamage.Rolls > 0)
                {
                    this.Attributes.Health -= this.TakeDamage(damage.MagicDamage, "magic damage", this.Attributes.MagicResistance);
                }

                if (damage.PiercingDamage.Rolls > 0)
                {
                    this.Attributes.Health -= this.TakeDamage(damage.PiercingDamage, "piercing damage", this.Attributes.AC);
                }

                if (damage.PoisonDamage.Rolls > 0)
                {
                    this.Attributes.Health -= this.TakeDamage(damage.PoisonDamage, "poison damage", this.Attributes.PoisonResistance);
                }

                if (damage.SlashingDamage.Rolls > 0)
                {
                    this.Attributes.Health -= this.TakeDamage(damage.SlashingDamage, "slashing damage", this.Attributes.AC);
                }
            }
            else
            {
                //Dodge
                Util.WriteLine(this.Name + " dodged!");
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Resets a bunch of stuff.
        /// </summary>
        public void Rest()
        {
            this.Abilities.Rest();
            this.Attributes.Rest();

            foreach (IAbility item in this.ClassAbilities)
            {
                item.Rest();
            }
        }

        public int XPValue()
        {
            return ExperienceCalculator.Calculate(this);
        }

        /// <summary>
        /// It's this creature's turn for action.
        /// </summary>
        /// <param name="encounter"></param>
        public void YourTurn(Encounter encounter)
        {
            if (this.IsInParty)
            {
                CombatControl.YourTurn(this, encounter);
            }
            else
            {
                this.myAI.YourTurn(encounter, this);
            }
        }
        public void YourTurn()
        {
            if (this.IsInParty)
            {
                NonCombatControl.YourTurn(this);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Takes damage
        /// </summary>
        /// <param name="elementalDamage"></param>
        /// <param name="nameOfDamage"></param>
        /// <param name="resistance"></param>
        /// <returns></returns>
        private double TakeDamage(Die elementalDamage, string nameOfDamage, double resistance)
        {
            double Damage = Dice.RollDice(elementalDamage, "Base incoming " + nameOfDamage);
            double DamageToReduce = Damage * resistance;
            double ActualDamage = Damage - DamageToReduce;
            Util.WriteLine(this.Name + " takes " + ActualDamage.ToString() + " " + nameOfDamage + " (" + resistance + "% resisted");
            return ActualDamage;
        }

        /// <summary>
        /// Returns a list of all items, whether they be in the inventory, or equipped somewhere.
        /// </summary>
        /// <returns></returns>
        public static List<IItem> GetAllItems(ICreature creature)
        {
            List<IItem> All = new List<IItem>();

            foreach (IItem item in creature.Amulets)
            {
                All.Add(item);
            }

            foreach (IItem item in creature.Armoring)
            {
                All.Add(item);
            }

            foreach (IItem item in creature.Inventory)
            {
                All.Add(item);
            }

            foreach (IItem item in creature.Rings)
            {
                All.Add(item);
            }

            foreach (IItem item in creature.Weapons)
            {
                All.Add(item);
            }

            return All;
        }
    }

    /// <summary>
    /// The type of creature this creature is.
    /// </summary>
    public enum CreatureType
    {
        Humanoid, Angelic, Demonic, Undead, Unknown
    }

    /// <summary>
    /// Used to store and compare alignments.
    /// </summary>
    public enum Alignment
    {
        LawfulGood, NeutralGood, ChaoticGood, LawfulNeutral, TrueNeutral, ChaoticNeutral, LawfulEvil, NeutralEvil, ChaoticEvil
    }

    /// <summary>
    /// Used to store and compare genders.
    /// </summary>
    public enum Gender
    {
        Male, Female, Unspecified
    }

    /// <summary>
    /// The race of the creature.
    /// </summary>
    public enum Race
    {
        Human, Elf, Dwarf, Kender, Drow, Duergar, HalfElf, Dragonborn, Planeswalker, Unspecified
    }
}