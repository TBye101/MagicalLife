using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Util;
using System.Collections.Generic;

namespace EarthMagicItems.Ammo.Arrows
{
    /// <summary>
    /// Storage for the generic arrows.
    /// </summary>
    public class GenericArrowStorage
    {
        #region NormalArrows

        private GenericAmmo _1Arrow = new GenericAmmo(new Die(2, 4, 0), "+1 Arrow", GenericArrowStorage.StandardArrow(new Die(1, 8, 1)), );
        private GenericAmmo _2Arrow = new GenericAmmo(new Die(3, 5, 0), "+2 Arrow", GenericArrowStorage.StandardArrow(new Die(1, 8, 2)), );
        private GenericAmmo _3Arrow = new GenericAmmo(new Die(4, 6, 0), "+3 Arrow", GenericArrowStorage.StandardArrow(new Die(1, 8, 3)), );
        private GenericAmmo _4Arrow = new GenericAmmo(new Die(5, 7, 0), "+4 Arrow", GenericArrowStorage.StandardArrow(new Die(1, 8, 4)), );
        private GenericAmmo _5Arrow = new GenericAmmo(new Die(6, 7, 0), "+5 Arrow", GenericArrowStorage.StandardArrow(new Die(1, 8, 5)), );
        private GenericAmmo HandMadeArrow = new GenericAmmo(new Die(1, 2, 0), "Handmade Arrow", GenericArrowStorage.StandardArrow(new Die(1, 6, 0)), );
        private GenericAmmo ProfessionalArrow = new GenericAmmo(new Die(1, 3, 0), "Professional Arrow", GenericArrowStorage.StandardArrow(new Die(1, 8, 0)), );

        #endregion NormalArrows

        private GenericAmmo AcidArrow = new GenericAmmo(new Die(1, 3, 0), "Acid Arrow", new Damage(new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero()), );
        private GenericAmmo FireArrow = new GenericAmmo(new Die(1, 3, 0), "Fire Arrow", new Damage(Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero()), );
        private GenericAmmo FrostArrow = new GenericAmmo(new Die(1, 3, 0), "Frost Arrow", new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero()), );
        private GenericAmmo PoisonArrow = new GenericAmmo(new Die(1, 3, 0), "Poison Arrow", new Damage(Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero()), );

        /// <summary>
        /// Creates a damage object for a arrow that only does normal piercing damage.
        /// </summary>
        /// <param name="piercingDamage"></param>
        /// <returns></returns>
        private static Damage StandardArrow(Die piercingDamage)
        {
            return new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), piercingDamage, Die.Zero(), Die.Zero());
        }
    }
}