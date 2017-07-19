using EarthWithMagicAPI.API.Interfaces.Items;
using EarthMagicDynamicMarket;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndFantasyLands.API.Items.Ammo.Arrows
{
    /// <summary>
    /// A slightly better arrow than the +3 arrows.
    /// </summary>
    public class _4Arrow : IAmmo
    {
        private Dice.Die _Uses = new Dice.Die(5, 7, 0);
        private bool _QuestItem = false;
        private int _Level = 8;
        private Guid _ID = new Guid();
        private string _Name = "Arrow +4";
        private int _ChanceToHit = 29;

        private List<string> _Lore = new List<string> { };
        private List<string> _OtherInfo = new List<string> { "Does 1d8 +4 piercing damage.", "This arrow COULD be used 7 times." };

        public _4Arrow()
        {

        }

        public Damage AttackDamage
        {
            get
            {
                return new Damage(new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 3), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0));
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
