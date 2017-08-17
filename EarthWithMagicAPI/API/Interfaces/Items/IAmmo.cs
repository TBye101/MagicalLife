using EarthWithMagicAPI.API.Util;

namespace EarthWithMagicAPI.API.Interfaces.Items
{
    /// <summary>
    /// Implemented by anything that is considered "ammo".
    /// </summary>
    public abstract class IAmmo : IItem
    {
        /// <summary>
        /// Gets the attack damage of the ammo.
        /// </summary>
        public Damage AttackDamage;

        /// <summary>
        /// The base chance to hit.
        /// </summary>
        public int ChanceToHit;

        /// <summary>
        /// The number of uses the ammo has.
        /// </summary>
        public Die Uses;
    }
}