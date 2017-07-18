using EarthWithMagicAPI.API;

namespace DungeonsAndFantasyLands.API.Items.Ammo
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
        int Uses { get; }

        /// <summary>
        /// The base chance to hit.
        /// </summary>
        int ChanceToHit { get; }
    }
}