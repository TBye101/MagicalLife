using EarthWithMagicAPI.API.Util;
using EarthWithMagicAPI.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthMagicItems.Ammo.Arrows
{
    /// <summary>
    /// Storage for the generic arrows.
    /// </summary>
    public class GenericArrowStorage
    {
        #region NormalArrows

        GenericAmmo HandMadeArrow = new GenericAmmo(new Dice.Die(1, 2, 0), false, 1, "Handmade Arrow", 10, GenericArrowStorage.StandardArrow(new Dice.Die(1, 6, 0)), new List<string> { }, new List<string> { });
        GenericAmmo ProfessionalArrow = new GenericAmmo(new Dice.Die(1, 3, 0), false, 2, "Professional Arrow", 17, GenericArrowStorage.StandardArrow(new Dice.Die(1, 8, 0)), new List<string> { }, new List<string> { });
        GenericAmmo _1Arrow = new GenericAmmo(new Dice.Die(2, 4, 0), false, 3, "+1 Arrow", 20, GenericArrowStorage.StandardArrow(new Dice.Die(1, 8, 1)), new List<string> { }, new List<string> { });
        GenericAmmo _2Arrow = new GenericAmmo(new Dice.Die(3, 5, 0), false, 5, "+2 Arrow", 23, GenericArrowStorage.StandardArrow(new Dice.Die(1, 8, 2)), new List<string> { }, new List<string> { });
        GenericAmmo _3Arrow = new GenericAmmo(new Dice.Die(4, 6, 0), false, 7, "+3 Arrow", 26, GenericArrowStorage.StandardArrow(new Dice.Die(1, 8, 3)), new List<string> { }, new List<string> { });
        GenericAmmo _4Arrow = new GenericAmmo(new Dice.Die(5, 7, 0), false, 9, "+4 Arrow", 29, GenericArrowStorage.StandardArrow(new Dice.Die(1, 8, 4)), new List<string> { }, new List<string> { });
        GenericAmmo _5Arrow = new GenericAmmo(new Dice.Die(6, 7, 0), false, 11, "+5 Arrow", 32, GenericArrowStorage.StandardArrow(new Dice.Die(1, 8, 5)), new List<string> { }, new List<string> { });

        #endregion

        GenericAmmo AcidArrow = new GenericAmmo(new Dice.Die(1, 3, 0), false, 3, "Acid Arrow", 17, new Damage(new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0)), new List<string> { }, new List<string> { });
        GenericAmmo FireArrow = new GenericAmmo(new Dice.Die(1, 3, 0), false, 3, "Fire Arrow", 17, new Damage(new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0)), new List<string> { }, new List<string> { });
        GenericAmmo FrostArrow = new GenericAmmo(new Dice.Die(1, 3, 0), false, 3, "Frost Arrow", 17, new Damage(new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0)), new List<string> { }, new List<string> { });
        GenericAmmo PoisonArrow = new GenericAmmo(new Dice.Die(1, 3, 0), false, 3, "Poison Arrow", 17, new Damage(new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0)), new List<string> { }, new List<string> { });

        /// <summary>
        /// Creates a damage object for a arrow that only does normal piercing damage.
        /// </summary>
        /// <param name="piercingDamage"></param>
        /// <returns></returns>
        private static Damage StandardArrow(Dice.Die piercingDamage)
        {
            return new Damage(new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), piercingDamage, new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0));
        }
    }
}
