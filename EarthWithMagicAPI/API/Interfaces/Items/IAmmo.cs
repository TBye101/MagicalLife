namespace EarthWithMagicAPI.API.Interfaces.Items
{
    using EarthWithMagicAPI.API.Util;

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

        public IAmmo(string name, double weight, string imagePath, string documentationPath) : base(name, weight, imagePath, documentationPath)
        {
        }
    }
}