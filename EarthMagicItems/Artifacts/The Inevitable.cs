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
        /// <summary>
        /// The constructor for The_Inevitable.
        /// </summary>
        public The_Inevitable()
        {
            this.AttackDamage = new Damage(new Die(2, 8, 5), new Die(2, 8, 5), new Die(2, 8, 5), new Die(2, 8, 5), new Die(2, 8, 5), new Die(2, 8, 5), new Die(2, 8, 5), Die.Zero(), Die.Zero());
            this.Uses = new Die(-1, -1, 0);
            this.ChanceToHit = 100;
            this.QuestItem = false;
            this.Level = 11;

            this.Lore = new List<string> { "Some say that The Inevitable was the very first magical arrow.",
        "Others say that it was the only sentient arrow ever made.",
            "The only thing the legends agree on is The Inevitable is fueled by the souls of it's victims.",
            "If The Inevitable cannot kill the entity it was shot at, it will attack creature's nearby until it kills one as a price for their betrayal." };

            this.Name = "The Inevitable";
            this.ID = new Guid();

            this.OtherInformation = new List<string> { "Does 2d8 +5 piercing damage.", "Does 2d8 +5 acid damage", "Does 2d8 +5 poison damage.",
            "Does 2d8 +5 electric damage.", "Does 2d8 + 5 fire damage.", "Does 2d8 +5 cold damage.",
        "Does 2d8 +5 magic damage." };

            this.Value = Pricer.GetPrice(this);
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

        public override void Bought()
        {
            throw new NotImplementedException();
        }

        public override void Equip()
        {
            throw new NotImplementedException();
        }

        public override StatsImpact EquipImpact()
        {
            throw new NotImplementedException();
        }

        public override void Sold()
        {
            throw new NotImplementedException();
        }

        public override void SpellHit(ISpell spell)
        {
            //Gotta handle a dispel here
            throw new NotImplementedException();
        }

        public override void Unequip()
        {
            throw new NotImplementedException();
        }

        public override void Use()
        {
            throw new NotImplementedException();
        }

        public override void WeaponHit(IWeapon attacker)
        {
            throw new NotImplementedException();
        }
    }
}