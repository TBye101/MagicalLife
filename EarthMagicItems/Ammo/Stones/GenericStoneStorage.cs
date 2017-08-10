using EarthMagicItems.Ammo.Arrows;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Util;
using System.Collections.Generic;

namespace EarthMagicItems.Ammo.Stones
{
    /// <summary>
    /// Storage for generic stones.
    /// </summary>
    public class GenericStoneStorage
    {
        #region NormalStones

        private GenericAmmo Stone = new GenericAmmo(new Die(1, 2, 0), false, 1, "Stone", 17, GenericStoneStorage.StandardStone(new Die(1, 4, 0)), new List<string> { }, new List<string> { });
        private GenericAmmo _1Stone = new GenericAmmo(new Die(2, 4, 0), false, 3, "+1 Stone", 23, GenericStoneStorage.StandardStone(new Die(1, 4, 1)), new List<string> { }, new List<string> { });
        private GenericAmmo _2Stone = new GenericAmmo(new Die(3, 5, 0), false, 5, "+2 Stone", 26, GenericStoneStorage.StandardStone(new Die(1, 4, 2)), new List<string> { }, new List<string> { });
        private GenericAmmo _3Stone = new GenericAmmo(new Die(4, 6, 0), false, 7, "+3 Stone", 29, GenericStoneStorage.StandardStone(new Die(1, 4, 3)), new List<string> { }, new List<string> { });
        private GenericAmmo _4Stone = new GenericAmmo(new Die(5, 7, 0), false, 9, "+4 Stone", 32, GenericStoneStorage.StandardStone(new Die(1, 4, 4)), new List<string> { }, new List<string> { });
        private GenericAmmo _5Stone = new GenericAmmo(new Die(6, 7, 0), false, 11, "+5 Stone", 35, GenericStoneStorage.StandardStone(new Die(1, 4, 5)), new List<string> { }, new List<string> { });

        #endregion NormalStones

        private GenericAmmo AcidStone = new GenericAmmo(new Die(1, 3, 0), false, 3, "Acid Stone", 17, new Damage(new Die(1, 8, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(1, 4, 0), new Die(0, 0, 0), new Die(0, 0, 0)), new List<string> { }, new List<string> { });
        private GenericAmmo FireStone = new GenericAmmo(new Die(1, 3, 0), false, 3, "Fire Stone", 17, new Damage(new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(1, 8, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(1, 4, 0), new Die(0, 0, 0), new Die(0, 0, 0)), new List<string> { }, new List<string> { });
        private GenericAmmo FrostStone = new GenericAmmo(new Die(1, 3, 0), false, 3, "Frost Stone", 17, new Damage(new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(1, 8, 0), new Die(0, 0, 0), new Die(1, 4, 0), new Die(0, 0, 0), new Die(0, 0, 0)), new List<string> { }, new List<string> { });
        private GenericAmmo PoisonStone = new GenericAmmo(new Die(1, 3, 0), false, 3, "Poison Stone", 17, new Damage(new Die(0, 0, 0), new Die(1, 8, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(1, 4, 0), new Die(0, 0, 0), new Die(0, 0, 0)), new List<string> { }, new List<string> { });

        /// <summary>
        /// Creates a damage object for a arrow that only does normal piercing damage.
        /// </summary>
        /// <param name="piercingDamage"></param>
        /// <returns></returns>
        private static Damage StandardStone(Die bluntDamage)
        {
            return new Damage(new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), new Die(0, 0, 0), bluntDamage);
        }
    }
}