using System.Security.Cryptography.X509Certificates;
namespace EarthWithMagicAPI.API.Interfaces.Items
{
    /// <summary>
    /// The interface of all weapons.
    /// </summary>
    public abstract class IWeapon
    {
        /// <summary>
        /// Called when this weapon is thrown.
        /// </summary>
        public abstract void OnThrow();

        /// <summary>
        /// Called whenever this weapon is attacked with.
        /// </summary>
        public abstract void OnAttack();

        /// <summary>
        /// Called by the creature when it wants to know what this weapon's attack roll is.
        /// </summary>
        /// <returns></returns>
        public abstract Damage Attack();
    }
}