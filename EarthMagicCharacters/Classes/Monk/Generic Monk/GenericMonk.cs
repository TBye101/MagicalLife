using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;
using System.Text;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Creature;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Stuff;

namespace EarthMagicCharacters.Classes.Monk.Generic_Monk
{
    /// <summary>
    /// The base monk.
    /// </summary>
    public class GenericMonk : ICharacter
    {
        private CreatureAttributes Attributes;

        /// <summary>
        /// Constructor for the GenericMonk class.
        /// </summary>
        public GenericMonk(int gender, int alignment, string name)
        {
            int startingHealth = Dice.RollDice(new Dice.Die(2, 10, 2));
            this.CreatureType = "Monk";
            this.Name = name;
            this.Title = "Trainee";
            this.Aligntment = alignment;


            Attributes = new CreatureAttributes(gender, 4, startingHealth, startingHealth,
            Dice.RollDice(new Dice.Die(3, 6, 0)), Dice.RollDice(new Dice.Die(3, 6, 0)),
            Dice.RollDice(new Dice.Die(3, 6, 0)), Dice.RollDice(new Dice.Die(3, 6, 0)),
            Dice.RollDice(new Dice.Die(3, 6, 0)), new XP(1), 0, 0, 0, 0, 0, 0, 0, 0, true, 12);
        }

        public override CreatureAttributes GetAttributes()
        {
            return this.Attributes;
        }

        public override bool IsHostile()
        {
            return false;
        }

        public override void LevelUp()
        {
            throw new NotImplementedException();
        }

        public override void OnCreatureDied(ICreature dead)
        {
            if (!dead.IsHostile() && Dice.RollDice(new Dice.Die(1, 100, 0)) > 80)
            {
                switch (this.Aligntment)
                {
                    //Lawful Evil
                    case 0:
                        Console.WriteLine(dead.Name + " was weak. " + this.HimHerIT() + "got what " + this.HimHerIT() + " deserved.");
                        break;
                    //Neutral
                    case 2:
                        Console.WriteLine("I never really knew " + dead.HimHerIT() + " very well.");
                        break;
                    //Lawful good
                    case 4:
                        Console.WriteLine("We have lost a comrade today. No matter " + dead.HimHerIT() + "'s personal struggles, " + dead.HimHerIT() + " was a valuable member of this party.");
                        break;
                    default:
                        throw new Exception("Alignment in Generic Monk not supported!");
                }
            }
        }

        public override void OnCreatureHealed(ICreature healer)
        {
        }

        public override void OnDealDamage()
        {
        }

        public override void OnItemEquipped(IItem item)
        {
        }

        public override void OnItemUnequipped(IItem item)
        {
        }

        public override void OnRecieveDamage(Damage damage)
        {
        }

        public override void YourTurn(Encounter encounter)
        {
            throw new NotImplementedException();
        }
    }
}
