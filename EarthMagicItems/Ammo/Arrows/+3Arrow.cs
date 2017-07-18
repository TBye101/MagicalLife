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
    /// A better version of the <see cref="_2Arrow"/>.
    /// </summary>
    public class _3Arrow : IAmmo
    {
        private int _Uses = Dice.RollDice(4, 6);
        private bool _QuestItem = false;
        private int _Value = 100;
        private Levels _Level = Levels.Level6;
        private Guid _ID = new Guid();
        private string _Name = "Arrow +3";
        private int _ChanceToHit = 16;

        private List<string> _Lore = new List<string> { "These arrows are far too expensive for the common folk.",
            "Before magical arrows were common for folks who could afford them, legend has it that a sorcerer made a magical and sentient arrow.",
        "The sentient arrow served it's master well, and was named \"The Inevitable\". Some say that if you get close to it, you can hear the screams of the lives it has taken."};
        private List<string> _OtherInfo = new List<string> { "Does 1d8 +3 piercing damage.", "This arrow COULD be used 6 times." };

        public _3Arrow()
        {

        }

        public Damage AttackDamage
        {
            get
            {
                return new Damage(0, 0, 0, 0, 0, Dice.RollDice(1, 8) + 3, 0, 0);
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
