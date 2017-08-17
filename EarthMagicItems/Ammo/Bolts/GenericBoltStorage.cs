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

        private GenericAmmo _1Bolt = new GenericAmmo(new Die(2, 4, 0), false, 3, "+1 Bolt", 23, GenericBoltStorage.StandardBolt(new Die(1, 6, 1)), new List<string> { }, new List<string> { });
        private GenericAmmo _2Bolt = new GenericAmmo(new Die(3, 5, 0), false, 5, "+2 Bolt", 26, GenericBoltStorage.StandardBolt(new Die(1, 6, 2)), new List<string> { }, new List<string> { });
        private GenericAmmo _3Bolt = new GenericAmmo(new Die(4, 6, 0), false, 7, "+3 Bolt", 29, GenericBoltStorage.StandardBolt(new Die(1, 6, 3)), new List<string> { }, new List<string> { });
        private GenericAmmo _4Bolt = new GenericAmmo(new Die(5, 7, 0), false, 9, "+4 Bolt", 32, GenericBoltStorage.StandardBolt(new Die(1, 6, 4)), new List<string> { }, new List<string> { });
        private GenericAmmo _5Bolt = new GenericAmmo(new Die(6, 7, 0), false, 11, "+5 Bolt", 35, GenericBoltStorage.StandardBolt(new Die(1, 6, 5)), new List<string> { }, new List<string> { });
        private GenericAmmo HandMadeBolt = new GenericAmmo(new Die(1, 2, 0), false, 1, "Handmade Bolt", 13, GenericBoltStorage.StandardBolt(new Die(1, 4, 0)), new List<string> { }, new List<string> { });
        private GenericAmmo ProfessionalBolt = new GenericAmmo(new Die(1, 3, 0), false, 2, "Professional Bolt", 20, GenericBoltStorage.StandardBolt(new Die(1, 6, 0)), new List<string> { }, new List<string> { });

        #endregion NormalBolts

        private GenericAmmo AcidBolt = new GenericAmmo(new Die(1, 3, 0), false, 3, "Acid Bolt", 17, new Damage(new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 6, 0), Die.Zero(), Die.Zero()), new List<string> { }, new List<string> { });
        private GenericAmmo FireBolt = new GenericAmmo(new Die(1, 3, 0), false, 3, "Fire Bolt", 17, new Damage(Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), new Die(1, 6, 0), Die.Zero(), Die.Zero()), new List<string> { }, new List<string> { });
        private GenericAmmo FrostBolt = new GenericAmmo(new Die(1, 3, 0), false, 3, "Frost Bolt", 17, new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), new Die(1, 6, 0), Die.Zero(), Die.Zero()), new List<string> { }, new List<string> { });
        private GenericAmmo PoisonBolt = new GenericAmmo(new Die(1, 3, 0), false, 3, "Poison Bolt", 17, new Damage(Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 6, 0), Die.Zero(), Die.Zero()), new List<string> { }, new List<string> { });

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