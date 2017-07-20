using EarthMagicDynamicMarket;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Interfaces.Spells;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthMagicItems.Ammo.Arrows
{
    public class GenericAmmo : IAmmo
    {
        private Dice.Die _Uses;
        private bool _QuestItem;
        private int _Level;
        private Guid _ID = new Guid();
        private string _Name;
        private int _ChanceToHit;
        private bool _IsEquipped = false;
        public Damage _AttackDamage;

        private List<string> _Lore;
        private List<string> _OtherInfo;

        public GenericAmmo(Dice.Die uses, bool questItem, int level, string name, int chanceToHit, Damage attackDamage, List<string> lore, List<string> otherInfo)
        {
            this._Uses = uses;
            this._QuestItem = questItem;
            this._Level = level;
            this._Name = name;
            this._ChanceToHit = chanceToHit;
            this._AttackDamage = attackDamage;
            this._Lore = lore;
            this._OtherInfo = otherInfo;
        }

        public Damage AttackDamage
        {
            get
            {
                return this._AttackDamage;
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

        public bool IsEquipped
        {
            get
            {
                return this._IsEquipped;
            }
        }

        public event EventHandler<IItem> ItemSold;
        public event EventHandler<IItem> ItemBought;
        public event EventHandler<IItem> ItemDropped;
        public event EventHandler<IItem> ItemPickedUp;
        public event EventHandler<IItem> ItemLost;
        public event EventHandler<IItem> ItemThrown;
        public event EventHandler<IItem> ItemDestroyed;
        public event EventHandler<IItem> ItemEquipped;
        public event EventHandler<IItem> StatusChanged;

        public void Bought()
        {

        }

        public void Equip()
        {

        }

        public void Sold()
        {

        }

        public void SpellHit(ISpell spell)
        {
            //Need to handle a dispell.
            throw new NotImplementedException();
        }

        public void Unequip()
        {

        }

        public void WeaponHit(IWeapon attacker)
        {

        }
    }
}
