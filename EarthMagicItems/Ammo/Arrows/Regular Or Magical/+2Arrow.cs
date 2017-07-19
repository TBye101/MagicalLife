using EarthMagicDynamicMarket;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;

namespace DungeonsAndFantasyLands.API.Items.Ammo.Arrows
{
    /// <summary>
    /// A better version of the <see cref="_1Arrow"/>.
    /// </summary>
    public class _2Arrow : IAmmo
    {
        private Dice.Die _Uses = new Dice.Die(3, 5, 0);
        private bool _QuestItem = false;
        private int _Level = 4;
        private Guid _ID = new Guid();
        private string _Name = "Arrow +2";
        private int _ChanceToHit = 23;

        private List<string> _Lore = new List<string> {};
        private List<string> _OtherInfo = new List<string> { "Does 1d8 +2 piercing damage.", "This arrow COULD be used 5 times." };

        public _2Arrow()
        {

        }

        public Damage AttackDamage
        {
            get
            {
                return new Damage(new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(2, 8, 2), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0));
            }
        }

        public Dice.Die Uses
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
                return Pricer.GetPrice(this);
            }
        }

        public int Level
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
