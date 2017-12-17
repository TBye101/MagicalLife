// <copyright file="GenericBoltStorage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicItems.Ammo.Bolts
{
    using EarthMagicItems.Ammo.Arrows;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// Storage for the generic bolts.
    /// </summary>
    public class GenericBoltStorage
    {
        private GenericAmmo ProfessionalBolt = new GenericAmmo(new Die(1, 3, 0), "Professional Bolt", AmmoUtil.StandardBolt(new Die(1, 6, 0)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.ProfessionalBolt.md", .15);

        private GenericAmmo AcidBolt = new GenericAmmo(new Die(1, 3, 0), "Acid Bolt", new Damage(new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 6, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.AcidBolt.md", .15);

        private GenericAmmo FireBolt = new GenericAmmo(new Die(1, 3, 0), "Fire Bolt", new Damage(Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), new Die(1, 6, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.FireBolt.md", .15);

        private GenericAmmo FrostBolt = new GenericAmmo(new Die(1, 3, 0), "Frost Bolt", new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), new Die(1, 6, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.FrostBolt.md", .15);

        private GenericAmmo PoisonBolt = new GenericAmmo(new Die(1, 3, 0), "Poison Bolt", new Damage(Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 6, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.PoisonBolt.md", .15);
    }
}