// <copyright file="ItemReg.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicItems
{
    using EarthMagicItems.Ammo.Arrows;
    using EarthMagicItems.Ammo.Bolts;
    using EarthMagicItems.Ammo.Stones;
    using EarthMagicItems.Armor.Generic.Steel;
    using EarthMagicItems.Gems;

    /// <summary>
    /// Holds all items
    /// </summary>
    public static class ItemReg
    {
        public static GenericArmorStorage Armor { get; set; } = new GenericArmorStorage();

        public static GenericArrowStorage Arrows { get; set; } = new GenericArrowStorage();

        public static GenericBoltStorage Bolts { get; set; } = new GenericBoltStorage();

        public static GenericGemStorage Gems { get; set; } = new GenericGemStorage();

        public static GenericStoneStorage Stones { get; set; } = new GenericStoneStorage();
    }
}