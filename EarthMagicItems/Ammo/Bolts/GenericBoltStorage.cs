using EarthMagicItems.Ammo.Arrows;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthMagicItems.Ammo.Bolts
{
    /// <summary>
    /// Storage for the generic bolts.
    /// </summary>
    public class GenericBoltStorage
    {
        #region NormalBolts

        GenericAmmo HandMadeBolt = new GenericAmmo(new Dice.Die(1, 2, 0), false, 1, "Handmade Bolt", 13, GenericBoltStorage.StandardBolt(new Dice.Die(1, 4, 0)), new List<string> { }, new List<string> { });
        GenericAmmo ProfessionalBolt = new GenericAmmo(new Dice.Die(1, 3, 0), false, 2, "Professional Bolt", 20, GenericBoltStorage.StandardBolt(new Dice.Die(1, 6, 0)), new List<string> { }, new List<string> { });
        GenericAmmo _1Bolt = new GenericAmmo(new Dice.Die(2, 4, 0), false, 3, "+1 Bolt", 23, GenericBoltStorage.StandardBolt(new Dice.Die(1, 6, 1)), new List<string> { }, new List<string> { });
        GenericAmmo _2Bolt = new GenericAmmo(new Dice.Die(3, 5, 0), false, 5, "+2 Bolt", 26, GenericBoltStorage.StandardBolt(new Dice.Die(1, 6, 2)), new List<string> { }, new List<string> { });
        GenericAmmo _3Bolt = new GenericAmmo(new Dice.Die(4, 6, 0), false, 7, "+3 Bolt", 29, GenericBoltStorage.StandardBolt(new Dice.Die(1, 6, 3)), new List<string> { }, new List<string> { });
        GenericAmmo _4Bolt = new GenericAmmo(new Dice.Die(5, 7, 0), false, 9, "+4 Bolt", 32, GenericBoltStorage.StandardBolt(new Dice.Die(1, 6, 4)), new List<string> { }, new List<string> { });
        GenericAmmo _5Bolt = new GenericAmmo(new Dice.Die(6, 7, 0), false, 11, "+5 Bolt", 35, GenericBoltStorage.StandardBolt(new Dice.Die(1, 6, 5)), new List<string> { }, new List<string> { });

        #endregion

        GenericAmmo AcidBolt = new GenericAmmo(new Dice.Die(1, 3, 0), false, 3, "Acid Bolt", 17, new Damage(new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 6, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0)), new List<string> { }, new List<string> { });
        GenericAmmo FireBolt = new GenericAmmo(new Dice.Die(1, 3, 0), false, 3, "Fire Bolt", 17, new Damage(new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 6, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0)), new List<string> { }, new List<string> { });
        GenericAmmo FrostBolt = new GenericAmmo(new Dice.Die(1, 3, 0), false, 3, "Frost Bolt", 17, new Damage(new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 6, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0)), new List<string> { }, new List<string> { });
        GenericAmmo PoisonBolt = new GenericAmmo(new Dice.Die(1, 3, 0), false, 3, "Poison Bolt", 17, new Damage(new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 6, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0)), new List<string> { }, new List<string> { });

        /// <summary>
        /// Creates a damage object for a arrow that only does normal piercing damage.
        /// </summary>
        /// <param name="piercingDamage"></param>
        /// <returns></returns>
        private static Damage StandardBolt(Dice.Die piercingDamage)
        {
            return new Damage(new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), piercingDamage, new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0));
        }
    }
}
