using EarthMagicDynamicMarket;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Interfaces.Spells;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;
using EarthWithMagicAPI.API.Creature;

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

        public override void Bought()
        {
            throw new NotImplementedException();
        }

        public override bool CanEquip(ICreature creature)
        {
            return true;
        }

        public override StatsImpact EquipImpact()
        {
            throw new NotImplementedException();
        }

        public override void Sold()
        {
        }

        public override void SpellHit(ISpell spell)
        {
            //Gotta handle a dispel here
            throw new NotImplementedException();
        }

        public override void Unequip()
        {
        }

        public override void Use()
        {
        }

        public override void WeaponHit(IWeapon attacker)
        {
        }
    }
}