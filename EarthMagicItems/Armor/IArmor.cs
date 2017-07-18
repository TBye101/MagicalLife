using EarthWithMagicAPI.API;

namespace DungeonsAndFantasyLands.API.Items
{
    /// <summary>
    /// Implemented by all armors.
    /// </summary>
    public interface IArmor : IItem
    {
        /// <summary>
        /// This is where we reduce incoming damage before it hits.
        /// </summary>
        /// <param name="Incoming"></param>
        /// <returns></returns>
        int ReduceDamage(Damage Incoming);
    }
}