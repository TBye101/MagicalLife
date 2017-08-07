namespace EarthWithMagicAPI.API.Interfaces.Items
{
    /// <summary>
    /// Implemented by all armors.
    /// </summary>
    public abstract class IArmor : IItem
    {
        /// <summary>
        /// The AC bonus of the armor.
        /// The higher, the better.
        /// The to hit roll must be higher than the creature's AC to hit.
        /// </summary>
        public int AC;
    }
}