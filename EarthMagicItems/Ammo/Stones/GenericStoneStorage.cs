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

        private GenericAmmo _1Stone = new GenericAmmo(new Die(2, 4, 0), "+1 Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 1)), );
        private GenericAmmo _2Stone = new GenericAmmo(new Die(3, 5, 0), "+2 Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 2)), );
        private GenericAmmo _3Stone = new GenericAmmo(new Die(4, 6, 0), "+3 Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 3)), );
        private GenericAmmo _4Stone = new GenericAmmo(new Die(5, 7, 0), "+4 Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 4)), );
        private GenericAmmo _5Stone = new GenericAmmo(new Die(6, 7, 0), "+5 Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 5)), );
        private GenericAmmo Stone = new GenericAmmo(new Die(1, 2, 0), "Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 0)), );

        #endregion NormalStones

        private GenericAmmo AcidStone = new GenericAmmo(new Die(1, 3, 0), false, 3, "Acid Stone", 17, new Damage(new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 4, 0), Die.Zero(), Die.Zero()), new List<string> { }, new List<string> { });
        private GenericAmmo FireStone = new GenericAmmo(new Die(1, 3, 0), false, 3, "Fire Stone", 17, new Damage(Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), new Die(1, 4, 0), Die.Zero(), Die.Zero()), new List<string> { }, new List<string> { });
        private GenericAmmo FrostStone = new GenericAmmo(new Die(1, 3, 0), false, 3, "Frost Stone", 17, new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), new Die(1, 4, 0), Die.Zero(), Die.Zero()), new List<string> { }, new List<string> { });
        private GenericAmmo PoisonStone = new GenericAmmo(new Die(1, 3, 0), false, 3, "Poison Stone", 17, new Damage(Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 4, 0), Die.Zero(), Die.Zero()), new List<string> { }, new List<string> { });

        /// <summary>
        /// Creates a damage object for a arrow that only does normal piercing damage.
        /// </summary>
        /// <param name="piercingDamage"></param>
        /// <param name="bluntDamage"></param>
        /// <returns></returns>
        private static Damage StandardStone(Die bluntDamage)
        {
            return new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), bluntDamage);
        }
    }
}