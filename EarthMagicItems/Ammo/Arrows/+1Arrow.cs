using DungeonsAndFantasyLands.API.Concepts;
using DungeonsAndFantasyLands.API.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DungeonsAndFantasyLands.Registries.Loot;

namespace DungeonsAndFantasyLands.API.Items.Ammo.Arrows
{
    /// <summary>
    /// A better version of the Professional Arrow.
    /// </summary>
    public class _1Arrow : IAmmo
    {
        private int _Uses = Dice.RollDice(2, 4);
        private bool _QuestItem = false;
        private int _Value = 25;
        private Levels _Level = Levels.Level3;
        private Guid _ID = new Guid();
        private string _Name = "Arrow +1";
        private int _ChanceToHit = 14;

        private List<string> _Lore = new List<string> { "These arrows were enchanted during the last war, and often used by rangers to kill infantry." };
        private List<string> _OtherInfo = new List<string> { "Does 1d8 +1 piercing damage.", "This arrow COULD be used 4 times."};

        public _1Arrow()
        {

        }

        public Damage AttackDamage
        {
            get
            {
                return new Damage(0, 0, 0, 0, 0, Dice.RollDice(1, 8) + 1, 0, 0);
            }
        }

        public int Uses
        {
            get
            {
                return this._Uses;
            }

            set
            {
                this._Uses = value;
            }
        }

        public bool QuestItem
        {
            get
            {
                return this._QuestItem;
            }

            set
            {
                this._QuestItem = value;
            }
        }

        public int Value
        {
            get
            {
                return this._Value;
            }

            set
            {
                this._Value = value;
            }
        }

        public Levels Level
        {
            get
            {
                return this._Level;
            }

            set
            {
                this._Level = value;
            }
        }

        public Guid ID
        {
            get
            {
                return this._ID;
            }

            set
            {
                this._ID = value;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }

            set
            {
                this._Name = value;
            }
        }

        public List<string> Lore
        {
            get
            {
                return this._Lore;
            }

            set
            {
                this._Lore = value;
            }
        }

        public List<string> OtherInformation
        {
            get
            {
                return this._OtherInfo;
            }

            set
            {
                this._OtherInfo = value;
            }
        }

        public int ChanceToHit
        {
            get
            {
                return this._ChanceToHit;
            }

            set
            {
                this._ChanceToHit = value;
            }
        }
    }
}
