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
                    this.Level2();
                    break;
                case 2:
                    this.Level3();
                    break;
                case 3:
                    this.Level4();
                    break;
                case 4:
                    this.Level5();
                    break;
                case 5:
                    this.Level6();
                    break;
                case 6:
                    this.Level7();
                    break;
                case 7:
                    this.Level8();
                    break;
                case 8:
                    this.Level9();
                    break;
                case 9:
                    this.Level10();
                    break;
                case 10:
                    this.Level11();
                    break;
                case 11:
                    this.Level12();
                    break;
                case 12:
                    this.Level13();
                    break;
                case 13:
                    this.Level14();
                    break;
                case 14:
                    this.Level15();
                    break;
                case 15:
                    this.Level16();
                    break;
                case 16:
                    this.Level17();
                    break;
                case 17:
                    this.Level18();
                    break;
                case 18:
                    this.Level19();
                    break;
                case 19:
                    this.Level20();
                    break;
                case 20:
                    this.Level21();
                    break;
                case 21:
                    this.Level22();
                    break;
                case 22:
                    this.Level23();
                    break;
                case 23:
                    this.Level24();
                    break;
                case 24:
                    this.Level25();
                    break;
                case 25:
                    this.Level26();
                    break;
                case 26:
                    this.Level27();
                    break;
                case 27:
                    this.Level28();
                    break;
                case 28:
                    this.Level29();
                    break;
                case 29:
                    this.Level30();
                    break;
                case 30:
                    this.Level31();
                    break;
                case 31:
                    this.Level32();
                    break;
                case 32:
                    this.Level33();
                    break;
                case 33:
                    this.Level34();
                    break;
                case 34:
                    this.Level35();
                    break;
                case 35:
                    this.Level36();
                    break;
                case 36:
                    this.Level37();
                    break;
                case 37:
                    this.Level38();
                    break;
                case 38:
                    this.Level39();
                    break;
                case 39:
                    this.Level40();
                    break;
                case 40:
                    this.Level41();
                    break;
                case 41:
                    this.Level42();
                    break;
                case 42:
                    this.Level43();
                    break;
                case 43:
                    this.Level44();
                    break;
                case 44:
                    this.Level45();
                    break;
                case 45:
                    this.Level46();
                    break;
                case 46:
                    this.Level47();
                    break;
                case 47:
                    this.Level48();
                    break;
                case 48:
                    this.Level49();
                    break;
                case 49:
                    this.Level50();
                    break;
                case 50:
                    this.Level51();
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
            List<string> levelUpReport = new List<string>();
            levelUpReport.Add("Level up report: ");
            levelUpReport.Add("+20% poison resistance.");
            levelUpReport.Add("+30% hide in shadows");
            levelUpReport.Add("+30% walk silently");
            levelUpReport.Add("HP: +  1d10 +2");
            levelUpReport.Add("To hit: +1");
            levelUpReport.Add("AC: +1");

            this.Attributes.PoisonResistence += 20;
            this.Abilities.HideInShadows += 30;
            this.Abilities.WalkSilently += 30;
            this.Attributes.MaxHealth += Dice.RollDice(new Dice.Die(1, 10, 2));
            this.Attributes.ToHit++;
            this.Attributes.AC++;
            Util.WriteLine(levelUpReport);
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
