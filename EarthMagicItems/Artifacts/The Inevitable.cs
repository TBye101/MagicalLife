using EarthMagicDynamicMarket;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Interfaces.Spells;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;

namespace DungeonsAndFantasyLands.API.Items.Ammo.Arrows.Artifacts
{
    /// <summary>
    /// Before magical arrows were common for folks who could afford them, legend has it that a sorcerer made a magical and sentient arrow.
    /// The sentient arrow served it's master well, and was named "The Inevitable". Some say that if you get close to it, you can hear the screams of the lives it has taken.
    /// </summary>
    public class The_Inevitable : IAmmo
    {
        private Dice.Die _Uses = new Dice.Die(-1, -1, 0);
        private bool _QuestItem = false;
        private int _Level = 11;
        private Guid _ID = new Guid();
        private string _Name = "The Inevitable";
        private int _ChanceToHit = 100;

        private List<string> _Lore = new List<string> { "Some say that The Inevitable was the very first magical arrow.",
        "Others say that it was the only sentient arrow ever made.",
            "The only thing the legends agree on is The Inevitable is fueled by the souls of it's victims.",
            "If The Inevitable cannot kill the entity it was shot at, it will attack creature's nearby until it kills one as a price for their betrayal." };

        private List<string> _OtherInfo = new List<string> { "Does 2d8 +5 piercing damage.", "Does 2d8 +5 acid damage", "Does 2d8 +5 poison damage.",
            "Does 2d8 +5 electric damage.", "Does 2d8 + 5 fire damage.", "Does 2d8 +5 cold damage.",
        "Does 2d8 +5 magic damage."};

        public The_Inevitable()
        {
        }

        public Damage AttackDamage
        {
            get
            {
                return new Damage(new Dice.Die(2, 8, 5), new Dice.Die(2, 8, 5), new Dice.Die(2, 8, 5), new Dice.Die(2, 8, 5), new Dice.Die(2, 8, 5), new Dice.Die(2, 8, 5), new Dice.Die(2, 8, 5), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0));
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
                throw new NotImplementedException();
            }
        }

        public double Weight
        {
            get
            {
                return .5;
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
            //Gotta handle a dispel here
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