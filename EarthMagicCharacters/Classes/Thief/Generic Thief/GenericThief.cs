using EarthWithMagicAPI.API.Creature;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Stuff;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;

namespace EarthMagicCharacters.Classes.Thief.Generic_Thief
{
    /// <summary>
    /// The generic thief class implementation.
    /// </summary>
    public class GenericThief : ICharacter
    {
        /// <summary>
        /// The AI used for the thief.
        /// </summary>
        public ThiefAI AI = new ThiefAI();

        private bool _Hostile;

        public GenericThief(Gender gender, Race race, Alignment alignment, string name = "Thief", bool isHostile = false) : base(GetAttributes(gender, race, alignment), GetAbilities(),
            "EarthMagicDocumentation.Classes.Thief_Class_Info.md", "EarthMagicDocumentation.ASCII_Art.Thief.txt", new ThiefAI())
        {
            this.CreatureType = "Thief";
            this.Name = name;
            this._Hostile = isHostile;
        }

        public override void EquipItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public override bool IsHostile()
        {
            return this._Hostile;
        }

        public override void LevelUp()
        {
            this.Attributes.BaseHealth += Dice.RollDice(new Die(1, 4, 3), this.Name + " gains hit points: ");

            switch (this.Attributes.XP.CreatureLevel)
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
            if (!dead.IsHostile() && Dice.RollDice(new Die(1, 100, 0)) > 80)
            {
                switch (Dice.RollDice(new Die(1, 2, 0)))
                {
                    case 1:
                        Console.WriteLine("Maybe I should have given " + dead.HimHerIT() + " the lucky coin back");
                        break;

                    case 2:
                        Console.Write("Now who is going to pull me out of trouble?");
                        break;

                    default:
                        throw new Exception("Error! Switch not handled!");
                }
            }
        }

        public override void OnCreatureHealed(ICreature healer)
        {
            throw new NotImplementedException();
        }

        public override void OnDealDamage()
        {
            throw new NotImplementedException();
        }

        public override void OnItemUnequipped(IItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the initial abilities of a thief.
        /// </summary>
        /// <returns></returns>
        private static CreatureAbilities GetAbilities()
        {
            return new CreatureAbilities();
        }

        /// <summary>
        /// Gets the initial attributes of a thief.
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="race"></param>
        /// <param name="alignment"></param>
        /// <returns></returns>
        private static CreatureAttributes GetAttributes(Gender gender, Race race, Alignment alignment)
        {
            int startingHealth = Dice.RollDice(new Die(2, 4, 3), "Starting Health");
            return new CreatureAttributes(gender, alignment, race, .03, startingHealth, startingHealth,
            Dice.RollDice(new Die(3, 6, 0), "Dexterity"), Dice.RollDice(new Die(3, 6, 0), "Strength"),
            Dice.RollDice(new Die(3, 6, 0), "Constitution"), Dice.RollDice(new Die(3, 6, 0), "Charisma"),
            Dice.RollDice(new Die(3, 6, 0), "Wisdom"), 0, 0, 0, 0, 0, 0, 0, 0, true, 30, .35, 0, Dice.RollDice(new Die(3, 6, 0), "Intelligence"));
        }

        #region LevelUps

        private void Level10()
        {
            List<string> report = new List<string> { "Title: Scout", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Scout";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level11()
        {
            List<string> report = new List<string> { "Title: Thief's Guild Associate", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Thief's Guild Associate";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level12()
        {
            List<string> report = new List<string> { "Title: Guild Marked", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Guild Marked";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level13()
        {
            List<string> report = new List<string> { "Title: Master Planner", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Master Planner";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level14()
        {
            List<string> report = new List<string> { "Title: Thief's Guild Member", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Thief's Guild Member";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level15()
        {
            List<string> report = new List<string> { "Title: Thief's Guild Sect Leader", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Thief's Guild Sect Leader";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level16()
        {
            List<string> report = new List<string> { "Title: Thief's Guild HQ Member", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Thief's Guild HQ Member";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level17()
        {
            List<string> report = new List<string> { "Title: Thief's Guild Leader", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Thief's Guild Leader";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level18()
        {
            List<string> report = new List<string> { "Title: Master Thief", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1", "Dexterity: +1"};

            this.Title = "Master Thief";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;
            this.Attributes.BaseDexterity++;

            Util.WriteLine(report);
        }

        private void Level19()
        {
            List<string> report = new List<string> { "Title: Asset Worker", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Asset Worker";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level2()
        {
            List<string> report = new List<string> { "Title: Hungry Orphan", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry Orphan";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level20()
        {
            List<string> report = new List<string> { "Title: Silent", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Silent";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level21()
        {
            List<string> report = new List<string> { "Title: Shadow Worker", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "Gain Darkvision"};

            this.Title = "Shadow Worker";
            this.Abilities.BaseDarkVision = true;
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level22()
        {
            List<string> report = new List<string> { "Title: Whispered Secret", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Whispered Secret";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level23()
        {
            List<string> report = new List<string> { "Title: Hoarder", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hoarder";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level24()
        {
            List<string> report = new List<string> { "Title: One of Quick Hands", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "One of Quick Hands";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level25()
        {
            List<string> report = new List<string> { "Title: One of Many Pockets", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "One of Many Pockets";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level26()
        {
            List<string> report = new List<string> { "Title: Silvertongue", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Silvertongue";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level27()
        {
            List<string> report = new List<string> { "Title: Goldtooth", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Goldtooth";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level28()
        {
            List<string> report = new List<string> { "Title: Diamond Eye", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Diamond Eye";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level29()
        {
            List<string> report = new List<string> { "Title: Platinum Ear", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Platinum Ear";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level3()
        {
            List<string> report = new List<string> { "Title: Kitchen Thief", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Kitchen Thief";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level30()
        {
            List<string> report = new List<string> { "Title: Deft Hand", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Deft Hand";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level31()
        {
            List<string> report = new List<string> { "Title: Shuffler", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Shuffler";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level32()
        {
            List<string> report = new List<string> { "Title: Bent Fence", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Bent Fence";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level33()
        {
            List<string> report = new List<string> { "Title: Sketchy Figure", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Sketchy Figure";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level34()
        {
            List<string> report = new List<string> { "Title: Shadow", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Shadow";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level35()
        {
            List<string> report = new List<string> { "Title: Legendary Whisper", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Legendary Whisper";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level36()
        {
            List<string> report = new List<string> { "Title: Silent Mist", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Silent Mist";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level37()
        {
            List<string> report = new List<string> { "Title: True Follower of Herzes", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "Dexterity: +1"};

            this.Title = "True Follower of Herzes";
            this.Abilities.BaseOpenLock += 2;
            this.Attributes.BaseDexterity++;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level38()
        {
            List<string> report = new List<string> { "Title: Collector", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Collector";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level39()
        {
            List<string> report = new List<string> { "Title: Well Equipped", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Well Equipped";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level4()
        {
            List<string> report = new List<string> { "Title: Orphan", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Orphan";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level40()
        {
            List<string> report = new List<string> { "Title: Gambler", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Gambler";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level41()
        {
            List<string> report = new List<string> { "Title: Liver of Chance", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Liver of Chance";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level42()
        {
            List<string> report = new List<string> { "Title: Mythical Whisper", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Mythical Whisper";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level43()
        {
            List<string> report = new List<string> { "Title: Exotic Item Collector", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Exotic Item Collector";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level44()
        {
            List<string> report = new List<string> { "Title: Hoard Amasser", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hoard Amasser";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level45()
        {
            List<string> report = new List<string> { "Title: Dragon's Jealousy", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Dragon's Jealousy";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level46()
        {
            List<string> report = new List<string> { "Title: Shining Thief", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Shining Thief";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level47()
        {
            List<string> report = new List<string> { "Title: Wraith", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Wraith";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level48()
        {
            List<string> report = new List<string> { "Title: Herzes' Favorite", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Herzes' Favorite";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level49()
        {
            List<string> report = new List<string> { "Title: Thief King", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Thief King";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level5()
        {
            List<string> report = new List<string> { "Title: Street Thief", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Street Thief";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level50()
        {
            List<string> report = new List<string> { "Title: Never Seen, Never Heard", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1", "Dexterity: +1"};

            this.Title = "Never Seen, Never Heard";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;
            this.Attributes.BaseDexterity++;

            Util.WriteLine(report);
        }

        private void Level51()
        {
            List<string> report = new List<string> { "Title: Ghost", "Dexterity: +1", "Constitution: +1", "Wisdom: +2", "Dodge: +3", "AC: +1" };

            this.Title = "Ghost";
            this.Attributes.BaseDexterity++;
            this.Attributes.BaseAC++;
            this.Attributes.BaseConstitution++;
            this.Attributes.BaseWisdom += 2;
            this.Attributes.BaseDodge += 3;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level6()
        {
            List<string> report = new List<string> { "Title: Gang Associate", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Gang Associate";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level7()
        {
            List<string> report = new List<string> { "Title: Gang Member", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Gang Member";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        private void Level8()
        {
            List<string> report = new List<string> { "Title: Recon Worker", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Recon Worker";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseBackstab += 3;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.AC++;

            Util.WriteLine(report);
        }

        private void Level9()
        {
            List<string> report = new List<string> { "Title: Target Planner", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Target Planner";
            this.Abilities.BaseOpenLock += 2;
            this.Abilities.BaseWalkSilently += 2;
            this.Abilities.BaseHideInShadows += 2;
            this.Abilities.BasePickPocket += 2;
            this.Abilities.BaseDetectTraps += 2;
            this.Abilities.BaseDisarmTraps += 2;
            this.Abilities.BaseDetectIllusions += 2;
            this.Attributes.BaseDodge += 3;

            Util.WriteLine(report);
        }

        #endregion LevelUps
    }
}