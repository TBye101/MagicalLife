namespace EarthMagicItems.Ammo
{
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// Used by various ammo items as a utility class.
    /// </summary>
    public static class AmmoUtil
    {
        /// <summary>
        /// Creates a damage object for a arrow that only does normal piercing damage.
        /// </summary>
        /// <param name="piercingDamage"></param>
        /// <returns></returns>
        public static Damage StandardArrow(Die piercingDamage)
        {
            return new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), piercingDamage, Die.Zero(), Die.Zero());
        }
    }
}
