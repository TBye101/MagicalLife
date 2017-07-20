using EarthMagicDynamicMarket;
using EarthWithMagicAPI.API.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthMagicItems.Gems
{
    /// <summary>
    /// The generic class for a gem.
    /// </summary>
    public class GenericGem : IGem
    {
        private bool _QuestItem;
        private int _Level;
        private Guid _ID = new Guid();
        private List<string> _OtherInformation;
        private List<string> _Lore;
        private string _Name;

        public GenericGem(bool questItem, int level, List<string> otherInformation, List<string> lore, string name)
        {
            this._QuestItem = questItem;
            this._Level = level;
            this._OtherInformation = otherInformation;
            this._Lore = lore;
            this._Name = name;
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
        }

        public Guid ID
        {
            get
            {
                return this._ID;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        public List<string> Lore
        {
            get
            {
                return this._Lore;
            }
        }

        public List<string> OtherInformation
        {
            get
            {
                return this._OtherInformation;
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
    }
}
