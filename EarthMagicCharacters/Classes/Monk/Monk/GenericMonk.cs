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
            Dice.RollDice(new Dice.Die(3, 6, 0)), new XP(1), 0, 0, 0, 0, 0, 0, 0, 0, true, 12, 40, 30);
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
            switch (this.Attributes.Xp.CreatureLevel)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                case 8:

                    break;
                case 9:

                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:

                    break;
                case 13:

                    break;
                case 14:

                    break;
                case 15:

                    break;
                case 16:

                    break;
                case 17:

                    break;
                case 18:

                    break;
                case 19:

                    break;
                case 20:

                    break;
                case 21:

                    break;
                case 22:

                    break;
                case 23:

                    break;
                case 24:

                    break;
                case 25:

                    break;
                case 26:

                    break;
                case 27:

                    break;
                case 28:

                    break;
                case 29:

                    break;
                case 30:

                    break;
                case 31:

                    break;
                case 32:

                    break;
                case 33:

                    break;
                case 34:

                    break;
                case 35:

                    break;
                case 36:

                    break;
                case 37:

                    break;
                case 38:

                    break;
                case 39:

                    break;
                case 40:

                    break;
                case 41:

                    break;
                case 42:

                    break;
                case 43:

                    break;
                case 44:

                    break;
                case 45:

                    break;
                case 46:

                    break;
                case 47:

                    break;
                case 48:

                    break;
                case 49:

                    break;
                case 50:

                    break;
                default:
                    Console.WriteLine("Level up not supported!");
                    break;
            }
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

        #region LevelUps

        private void Level2()
        {

        }

        private void Level3()
        {

        }

        private void Level4()
        {

        }

        private void Level5()
        {

        }

        private void Level6()
        {

        }

        private void Level7()
        {

        }

        private void Level8()
        {

        }

        private void Level9()
        {

        }

        private void Level10()
        {

        }

        private void Level11()
        {

        }

        private void Level12()
        {

        }

        private void Level13()
        {

        }

        private void Level14()
        {

        }

        private void Level15()
        {

        }

        private void Level16()
        {

        }

        private void Level17()
        {

        }

        private void Level18()
        {

        }

        private void Level19()
        {

        }

        private void Level20()
        {

        }

        private void Level21()
        {

        }

        private void Level22()
        {

        }

        private void Level23()
        {

        }

        private void Level24()
        {

        }

        private void Level25()
        {

        }

        private void Level26()
        {

        }

        private void Level27()
        {

        }

        private void Level28()
        {

        }

        private void Level29()
        {

        }

        private void Level30()
        {

        }

        private void Level31()
        {

        }

        private void Level32()
        {

        }

        private void Level33()
        {

        }

        private void Level34()
        {

        }

        private void Level35()
        {

        }

        private void Level36()
        {

        }

        private void Level37()
        {

        }

        private void Level38()
        {

        }

        private void Level39()
        {

        }

        private void Level40()
        {

        }

        private void Level41()
        {

        }

        private void Level42()
        {

        }

        private void Level43()
        {

        }

        private void Level44()
        {

        }

        private void Level45()
        {

        }

        private void Level46()
        {

        }

        private void Level47()
        {

        }

        private void Level48()
        {

        }

        private void Level49()
        {

        }

        private void Level50()
        {

        }

        private void Level51()
        {

        }

        #endregion
    }
}
