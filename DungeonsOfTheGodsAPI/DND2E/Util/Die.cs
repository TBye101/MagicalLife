using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND2E.Util
{
    /// <summary>
    /// A single die.
    /// </summary>
    public class Die
    {
        private Random rng = new Random();

        /// <summary>
        /// The number of sides on this die.
        /// </summary>
        private int sides;

        public Die(int sides)
        {
            this.sides = sides;
        }

        /// <summary>
        /// Rolls this die a number of times, and returns the sum of the values.
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public int Roll(int times)
        {
            int sum = 0;

            while (times != 0)
            {
                sum += this.rng.Next(1, this.sides + 1);
                times--;
            }

            return sum;
        }
    }
}
