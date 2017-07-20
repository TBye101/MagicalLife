using System;

namespace EarthWithMagicAPI.API.Util
{
    /// <summary>
    /// Simulated dice roller.
    /// </summary>
    public static class Dice
    {
        public static Random Rand = new Random();

        /// <summary>
        /// Rolls dice, adds up the values, and returns the number.
        /// </summary>
        /// <param name="DiceRolls">How many times to roll the die.</param>
        /// <param name="Sides">How many sides on the die.</param>
        /// <returns></returns>
        public static int RollDice(int DiceRolls, int Sides)
        {
            int ret = 0;

            while (DiceRolls > 0)
            {
                ret += Rand.Next(1, Sides);
                DiceRolls--;
            }

            return ret;
        }

        public static int RollDice(Die die)
        {
            int ret = 0;

            while (die.Rolls > 0)
            {
                ret += Rand.Next(1, die.Sides);
                die.Rolls--;
            }

            ret += die.Modifyer;
            return ret;
        }

        /// <summary>
        /// Used to store dice rolls.
        /// </summary>
        public struct Die
        {
            public int Rolls;
            public int Sides;

            /// <summary>
            /// Your +Damage.
            /// </summary>
            public int Modifyer;

            /// <summary>
            /// The constructor for the Die struct.
            /// </summary>
            /// <param name="rolls">The number of rolls of the die you want.</param>
            /// <param name="sides">The number of sides on the die.</param>
            /// <param name="modifyer">Any guaranteed damage, such as a +1.</param>
            public Die(int rolls, int sides, int modifyer)
            {
                this.Rolls = rolls;
                this.Sides = sides;
                this.Modifyer = modifyer;
            }
        }
    }
}