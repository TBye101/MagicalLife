using System.Linq;
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
        /// <returns></returns>
        public static int RollDice(Die die, string Description = "")
        {
            int ret = 0;
            int OriginalRolls = die.Rolls;
            while (die.Rolls > 0)
            {
                ret += Rand.Next(1, die.Sides);
                die.Rolls--;
            }

            ret += die.Modifyer;

            string ToLog = Description;
            ToLog += ": ";
            ToLog += OriginalRolls.ToString();
            ToLog += "d";
            ToLog += die.Sides.ToString();

            if (die.Modifyer > 0)
            {
                ToLog += " +";
                ToLog += die.Modifyer.ToString();
            }

            ToLog += " -> ";
            ToLog += ret.ToString();
            Util.WriteLine(ToLog);

            return ret;
        }
    }


    /// <summary>
    /// Used to store dice rolls.
    /// </summary>
    public struct Die
    {
        /// <summary>
        /// Rolls of the die.
        /// </summary>
        public int Rolls;

        /// <summary>
        /// Number of sides on the die.
        /// </summary>
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

        public static Die Zero()
        {
            return new Die(0, 0, 0);
        }
    }
}