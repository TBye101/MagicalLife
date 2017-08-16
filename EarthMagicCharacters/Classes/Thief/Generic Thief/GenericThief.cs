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
            throw new NotImplementedException();
        }

        private void Level49()
        {
            throw new NotImplementedException();
        }

        private void Level48()
        {
            throw new NotImplementedException();
        }

        private void Level47()
        {
            throw new NotImplementedException();
        }

        private void Level46()
        {
            throw new NotImplementedException();
        }

        private void Level45()
        {
            throw new NotImplementedException();
        }

        private void Level44()
        {
            throw new NotImplementedException();
        }

        private void Level43()
        {
            throw new NotImplementedException();
        }

        private void Level42()
        {
            throw new NotImplementedException();
        }

        private void Level41()
        {
            throw new NotImplementedException();
        }

        private void Level40()
        {
            throw new NotImplementedException();
        }

        private void Level39()
        {
            throw new NotImplementedException();
        }

        private void Level38()
        {
            throw new NotImplementedException();
        }

        private void Level37()
        {
            throw new NotImplementedException();
        }

        private void Level36()
        {
            throw new NotImplementedException();
        }

        private void Level35()
        {
            throw new NotImplementedException();
        }

        private void Level34()
        {
            throw new NotImplementedException();
        }

        private void Level33()
        {
            throw new NotImplementedException();
        }

        private void Level32()
        {
            throw new NotImplementedException();
        }

        private void Level31()
        {
            throw new NotImplementedException();
        }

        private void Level30()
        {
            throw new NotImplementedException();
        }

        private void Level29()
        {
            throw new NotImplementedException();
        }

        private void Level28()
        {
            throw new NotImplementedException();
        }

        private void Level27()
        {
            throw new NotImplementedException();
        }

        private void Level26()
        {
            throw new NotImplementedException();
        }

        private void Level25()
        {
            throw new NotImplementedException();
        }

        private void Level24()
        {
            throw new NotImplementedException();
        }

        private void Level23()
        {
            throw new NotImplementedException();
        }

        private void Level22()
        {
            throw new NotImplementedException();
        }

        private void Level21()
        {
            throw new NotImplementedException();
        }

        private void Level20()
        {
            throw new NotImplementedException();
        }

        private void Level19()
        {
            throw new NotImplementedException();
        }

        private void Level18()
        {
            throw new NotImplementedException();
        }

        private void Level17()
        {
            throw new NotImplementedException();
        }

        private void Level16()
        {
            throw new NotImplementedException();
        }

        private void Level15()
        {
            throw new NotImplementedException();
        }

        private void Level14()
        {
            throw new NotImplementedException();
        }

        private void Level13()
        {
            throw new NotImplementedException();
        }

        private void Level12()
        {
            throw new NotImplementedException();
        }

        private void Level11()
        {
            throw new NotImplementedException();
        }

        private void Level10()
        {
            throw new NotImplementedException();
        }

        private void Level9()
        {
            throw new NotImplementedException();
        }

        private void Level8()
        {
            throw new NotImplementedException();
        }

        private void Level7()
        {
            throw new NotImplementedException();
        }

        private void Level6()
        {
            throw new NotImplementedException();
        }

        private void Level5()
        {
            throw new NotImplementedException();
        }

        private void Level4()
        {
            throw new NotImplementedException();
        }

        private void Level3()
        {
            throw new NotImplementedException();
        }

        private void Level2()
        {
            throw new NotImplementedException();
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
