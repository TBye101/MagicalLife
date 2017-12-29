using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND2E.Util
{
    /// <summary>
    /// Handles a lot of stuff involving <see cref="Die"/> rolling.
    /// </summary>
    public static class Dice
    {
        /// <summary>
        /// Rolls a die a number of times, adds the values rolled together and returns this value.
        /// </summary>
        /// <param name="times"></param>
        /// <param name="sides"></param>
        /// <param name="modifier">The amount to add or subtract from the roll after the roll.</param>
        /// <returns></returns>
        public static int Roll(int times, int sides, int modifier)
        {
            Die die = new Die(sides, modifier);
            int sum = die.Roll(times);

            Output.Writeline(times.ToString() + "d" + sides.ToString() + "+" + modifier.ToString() + " -> " + sum.ToString());
            return sum;
        }
    }
}
