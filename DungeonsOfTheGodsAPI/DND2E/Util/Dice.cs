using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND2E.Util
{
    /// <summary>
    /// Handles a lot of stuff involving dice rolling.
    /// </summary>
    public static class Dice
    {
        /// <summary>
        /// Rolls a die a number of times, adds the values rolled together and returns this value.
        /// </summary>
        /// <param name="times"></param>
        /// <param name="sides"></param>
        /// <returns></returns>
        public static int Roll(int times, int sides)
        {
            Die die = new Die(sides);
            int sum = die.Roll(times);

            Output.Writeline(times.ToString() + "d" + sides.ToString() + " -> " + sum.ToString());
            return sum;
        }
    }
}
