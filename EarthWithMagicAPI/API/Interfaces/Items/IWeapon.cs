using EarthWithMagicAPI.API.Creature;

namespace EarthWithMagicAPI.API.Interfaces.Items
{
    /// <summary>
    /// The interface of all weapons.
    /// </summary>
    public abstract class IWeapon : IItem
    {
        /// <summary>
        /// Called when attacking another creature.
        /// </summary>
        /// <param name="creature"></param>
        /// <returns></returns>
        public void Attack(ICreature creature)
        {
            creature.RecieveDamage(this.Damage);
        }

        /// <summary>
        /// Called whenever this weapon is attacked with.
        /// </summary>
        public abstract void OnAttack();

        /// <summary>
        /// Called when this weapon is thrown.
        /// </summary>
        public abstract void OnThrow();
    }
}