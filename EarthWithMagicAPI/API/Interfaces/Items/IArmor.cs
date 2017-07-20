using EarthWithMagicAPI.API.Interfaces.Items;

namespace EarthWithMagicAPI.API.Interfaces.Items
{
    /// <summary>
    /// Implemented by all armors.
    /// </summary>
    public interface IArmor : IItem
    {
        /// <summary>
        /// The AC bonus of the armor.
        /// The higher, the better.
        /// The to hit roll must be higher than the creature's AC to hit.
        /// </summary>
        int AC { get;}

        
    }
}