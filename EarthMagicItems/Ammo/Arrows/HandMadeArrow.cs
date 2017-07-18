using DungeonsAndFantasyLands.API.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsAndFantasyLands.API.Concepts;
using static DungeonsAndFantasyLands.Registries.Loot;

namespace DungeonsAndFantasyLands.API.Items.Ammo.Arrows
{
    /// <summary>
    /// The worst arrow.
    /// </summary>
    public class HandMadeArrow : IAmmo
    {
        private int _Uses = Dice.RollDice(1, 2);
        private bool _QuestItem = false;
        private int _Value = 10;
        private Levels _Level = Levels.Level1;
        private Guid _ID = new Guid();
        private string _Name = "Handmade Arrow";
        private int _ChanceToHit = 10;

        private List<string> _Lore = new List<string> { "Someone or something has made these arrows by hand.", "It doesn't look like they really know what they are doing." };
        private List<string> _OtherInfo = new List<string> { "Does 1d6 piercing damage.", "If you are lucky, you get to use this arrow twice" };

        public HandMadeArrow()
        {

        }

        public Damage AttackDamage
        {
            get
            {
                return new Damage(0, 0, 0, 0, 0, Dice.RollDice(1, 6), 0, 0);
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
