using EarthMagicItems.Ammo.Arrows;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Util;
using System.Collections.Generic;

namespace EarthMagicItems.Ammo.Bolts
{
    /// <summary>
    /// Storage for the generic bolts.
    /// </summary>
    public class GenericBoltStorage
    {
        #region NormalBolts

        private GenericAmmo _1Bolt = new GenericAmmo(new Die(2, 4, 0), "+1 Bolt", GenericBoltStorage.StandardBolt(new Die(1, 6, 1)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt", 
            "EarthMagicDocumentation.Items.Ammo.Bolts.+1Bolt.md", .15);

        private GenericAmmo _2Bolt = new GenericAmmo(new Die(3, 5, 0), "+2 Bolt", GenericBoltStorage.StandardBolt(new Die(1, 6, 2)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.+2Bolt.md", .15);

        private GenericAmmo _3Bolt = new GenericAmmo(new Die(4, 6, 0), "+3 Bolt", GenericBoltStorage.StandardBolt(new Die(1, 6, 3)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.+3Bolt.md", .15);

        private GenericAmmo _4Bolt = new GenericAmmo(new Die(5, 7, 0), "+4 Bolt", GenericBoltStorage.StandardBolt(new Die(1, 6, 4)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.+4Bolt.md", .15);

        private GenericAmmo _5Bolt = new GenericAmmo(new Die(6, 7, 0), "+5 Bolt", GenericBoltStorage.StandardBolt(new Die(1, 6, 5)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.+5Bolt.md", .15);

        private GenericAmmo HandMadeBolt = new GenericAmmo(new Die(1, 2, 0), "Handmade Bolt", GenericBoltStorage.StandardBolt(new Die(1, 4, 0)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.HandMadeBolt.md", .25);

        private GenericAmmo ProfessionalBolt = new GenericAmmo(new Die(1, 3, 0), "Professional Bolt", GenericBoltStorage.StandardBolt(new Die(1, 6, 0)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.ProfessionalBolt.md", .15);

        #endregion NormalBolts

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

        /// <summary>
        /// Creates a damage object for a arrow that only does normal piercing damage.
        /// </summary>
        /// <param name="piercingDamage"></param>
        /// <returns></returns>
        private static Damage StandardBolt(Die piercingDamage)
        {
            return new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), piercingDamage, Die.Zero(), Die.Zero());
        }
    }
}