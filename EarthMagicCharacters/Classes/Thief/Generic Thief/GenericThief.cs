using System;
using System.Collections.Generic;
using System.Text;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Creature;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Stuff;
using EarthWithMagicAPI.API.Util;

namespace EarthMagicCharacters.Classes.Thief.Generic_Thief
{
    /// <summary>
    /// The generic thief class implementation.
    /// </summary>
    public class GenericThief : ICharacter
    {
        public GenericThief(CreatureAttributes attributes, CreatureAbilities abilities) : base(attributes, abilities)
        {
        }

        public override void EncounterEnded(Encounter fight)
        {
            throw new NotImplementedException();
        }

        public override void EquipItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public override CreatureAttributes GetAttributes()
        {
            throw new NotImplementedException();
        }

        public override bool IsHostile()
        {
            throw new NotImplementedException();
        }

        public override void LevelUp()
        {
            this.Attributes.BaseHealth += Dice.RollDice(new Die(1, 10, 2), this.Name + " gains hit points: ");

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

        private void Level51()
        {
            throw new NotImplementedException();
        }

        private void Level50()
        {
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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

        private void Level40()
        {
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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

        private void Level38()
        {
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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

        private void Level20()
        {
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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

        private void Level19()
        {
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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

        private void Level10()
        {
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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

        private void Level6()
        {
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Backstab: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2", "AC: +1"};

            this.Title = "Hungry";
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

        private void Level5()
        {
            List<string> report = new List<string> { "Title: Hungry", "Open Lock: +2", "Dodge: +3", "Walk Silently: +2", "Hide in Shadows: +2",
            "Pickpocket: +2", "Detect Traps: +2", "Disarm Traps: +2", "Detect Illusions: +2"};

            this.Title = "Hungry";
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

        public override void OnCreatureDied(ICreature dead)
        {
            throw new NotImplementedException();
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

        public override void RecieveDamage(Damage damage)
        {
            throw new NotImplementedException();
        }

        public override void YourTurn(Encounter encounter)
        {
            throw new NotImplementedException();
        }
    }
}
