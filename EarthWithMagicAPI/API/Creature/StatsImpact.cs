// <copyright file="IItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Creature
{
    using System;
    using EarthMagicDocumentation;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Stuff;

    /// <summary>
    /// Holds the impact an item will have on a player's stats.
    /// Ex: If you set Strength to -2, the player that equips this will have their strength lowered by 2.
    /// </summary>
    public class StatsImpact
    {


        public StatsImpact()
        {
        }

        public StatsImpact(int charisma, int dexterity, int strength, int constitution, int wisdom, int ac,
            int health, int weightCapacity, int fireResistance, int acidResistance, int poisonResistance, int electricResistance, int coldResistance, int magicResistance, int charmResistance,
            int sleepResistance, int initiative, int dodge, int lockpick, int walkSilently)
        {
            this.Charisma = charisma;
            this.Dexterity = dexterity;
            this.Strength = strength;
            this.Constitution = constitution;
            this.Wisdom = wisdom;

            this.AC = ac;
            this.Health = health;
            this.WeightCapacity = weightCapacity;
            this.FireResistance = fireResistance;
            this.AcidResistance = acidResistance;
            this.PoisonResistance = poisonResistance;
            this.ElectricResistance = electricResistance;
            this.ColdResistance = coldResistance;
            this.MagicResistance = magicResistance;
            this.CharmResistance = charmResistance;
            this.SleepResistance = sleepResistance;
            this.Initiative = initiative;
            this.Dodge = dodge;
            this.Lockpick = lockpick;
            this.WalkSilently = walkSilently;
        }

        public int AC { get; set; } = 0;

        public int AcidResistance { get; set; } = 0;

        public int Charisma { get; set; } = 0;

        public int CharmResistance { get; set; } = 0;

        public int ColdResistance { get; set; } = 0;

        public int Constitution { get; set; } = 0;

        public int Dexterity { get; set; } = 0;

        public int Dodge { get; set; } = 0;

        public int ElectricResistance { get; set; } = 0;

        public int FireResistance { get; set; } = 0;

        public int Health { get; set; } = 0;

        public int Initiative { get; set; } = 0;

        public int Lockpick { get; set; } = 0;

        public int MagicResistance { get; set; } = 0;

        public int PoisonResistance { get; set; } = 0;

        public int SleepResistance { get; set; } = 0;

        public int Strength { get; set; } = 0;

        public int WalkSilently { get; set; } = 0;

        public int WeightCapacity { get; set; } = 0;

        public int Wisdom { get; set; } = 0;
    }
}