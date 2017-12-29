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
        private readonly Random rng = new Random();

        /// <summary>
        /// The number of sides on this <see cref="Die"/>.
        /// </summary>
        private readonly int sides;

        /// <summary>
        /// The amount to be added or subtracted from the roll after each roll.
        /// </summary>
        private readonly int modifier;

        public Die(int sides, int modifier)
        {
            this.sides = sides;
            this.modifier = modifier;
        }

        /// <summary>
        /// Rolls this <see cref="Die"/> a number of times, and returns the sum of the values.
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
            sum += times * this.modifier;

            return sum;
        }
    }
}
