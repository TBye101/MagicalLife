using EarthWithMagicAPI.API.Util;
using EarthWithMagicAPI.API;

namespace EarthWithMagicAPI.API.Interfaces.Items
{
    /// <summary>
    /// Implemented by anything that is considered "ammo".
    /// </summary>
    public interface IAmmo : IItem
    {
        /// <summary>
        /// Gets the attack damage of the ammo.
        /// </summary>
        Damage AttackDamage { get; }

        /// <summary>
        /// The number of uses the ammo has. 
        /// </summary>
        Dice.Die Uses { get; }

        /// <summary>
        /// The base chance to hit.
        /// </summary>
        int ChanceToHit { get; }
    }
}