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
        /// <summary>
        /// The maximum amount of stunning blows this monk could use.
        /// </summary>
        private int MaxStunningBlows = 0;

        /// <summary>
        /// The amount of stunning blows this monk has left.
        /// </summary>
        private int StunningBlows = 0;

        /// <summary>
        /// The attributes of this monk.
        /// </summary>
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
            this.Alignment = alignment;


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
                switch (this.Alignment)
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

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level2()
        {
            List<string> levelUpReport = new List<string>();
            levelUpReport.Add("Level up report: ");
            levelUpReport.Add("Title: Faithless");
            levelUpReport.Add("HP: +  1d10 +2");
            levelUpReport.Add("AC: +1");
            levelUpReport.Add("To hit: +1");
            levelUpReport.Add("+20% poison resistance.");
            levelUpReport.Add("+30% hide in shadows");
            levelUpReport.Add("+30% walk silently");

            this.Attributes.PoisonResistence += 20;
            this.Abilities.HideInShadows += 30;
            this.Abilities.WalkSilently += 30;
            this.Attributes.MaxHealth += Dice.RollDice(new Dice.Die(1, 10, 2));
            this.Attributes.ToHit++;
            this.Attributes.AC++;
            this.Title = "Faithless";
            Util.WriteLine(levelUpReport);
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level3()
        {
            List<string> levelUpReport = new List<string>();

            levelUpReport.Add("Title: Faithful");
            levelUpReport.Add("AC: +1");
            levelUpReport.Add("+20% fire resistance");

            this.Title = "Faithful";
            ++this.Attributes.AC;
            this.Attributes.FireResistence += 20;

            Util.WriteLine(levelUpReport);
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level4()
        {
            List<string> levelUpReport = new List<string> { "Apprentice", "AC: +1", "To hit +1", "+5% hide in shadows", "+5% walk silently"};

            this.Abilities.HideInShadows += 5;
            this.Abilities.WalkSilently += 5;
            ++this.Attributes.ToHit;
            ++this.Attributes.AC;
            this.Title = "Apprentice";

            Util.WriteLine(levelUpReport);
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level5()
        {
            List<string> levelUpReport = new List<string> { "Title: Faithful Apprentice", "+1 stunning blow", "Fist: 1d10", "AC: +1"};

            this.Title = "Faithful Apprentice";
            ++this.MaxStunningBlows;
            ++this.Attributes.AC;
            this.BareHands.FistDamage.BluntDamage = new Dice.Die(1, 10, 0);

            Util.WriteLine(levelUpReport);
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level6()
        {
            List<string> levelUpReport = new List<string> { "Title: Novice", "+20% cold resistance", "+5% hide in shadows", "+5% walk silently", "To hit: +1", "Ac: +1" };

            this.Title = "Novice";
            this.Attributes.ColdResistence += 20;
            this.Abilities.HideInShadows += 5;
            this.Abilities.WalkSilently += 5;
            ++this.Attributes.ToHit;
            ++this.Attributes.AC;

            Util.WriteLine(levelUpReport);
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level7()
        { 
            List<string> levelUpReport = new List<string> { "Title: Brother", "+20% resistance to sleep", "AC: +1"};

            this.Title = "Brother";
            this.Attributes.SleepResistence += 20;
            ++this.Attributes.AC;

            Util.WriteLine(levelUpReport);
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level8()
        {
            List<string> levelUpReport = new List<string> { "Title: Faithful Brother", "+20% resistance to charms", "+5% hide in shadows", "+5% walk silently", "To hit +1", "AC: +1"};

            this.Title = "Faithful Brother";
            this.Attributes.CharmResistence += 20;
            this.Abilities.HideInShadows += 5;
            this.Abilities.WalkSilently += 5;
            ++this.Attributes.ToHit;
            ++this.Attributes.AC;

            Util.WriteLine(levelUpReport);
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level9()
        {
            List<string> levelUpReport = new List<string> { "Title: Disciple", "+5% magic resistance", "Fist: 1d10 +1", "AC: +1"};

            this.Title = "Disciple";
            this.Attributes.MagicResistence += 5;
            this.BareHands.FistDamage.BluntDamage = new Dice.Die(1, 10, 1);
            this.Attributes.AC++;

            Util.WriteLine(levelUpReport);
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level10()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level11()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level12()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level13()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level14()
        {
            List<string> levelUpReport = new List<string> {   };

        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level15()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level16()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level17()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level18()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level19()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level20()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level21()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level22()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level23()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level24()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level25()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level26()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level27()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level28()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level29()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level30()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level31()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level32()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level33()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level34()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level35()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level36()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level37()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level38()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level39()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level40()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level41()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level42()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level43()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level44()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level45()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level46()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level47()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level48()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level49()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level50()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        /// <summary>
        /// Does level up logic to bring the monk up to the next level.
        /// </summary>
        private void Level51()
        {
            List<string> levelUpReport = new List<string> {   };
        }

        #endregion
    }
}
