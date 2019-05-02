using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Util
{
    /// <summary>
    /// Used to choose values from a list of values with unequal weights.
    /// </summary>
    public class WeightedRandom
    {
        private List<int> Weights;

        private Random RNG;

        private int TotalWeight;

        /// <param name="weights">The weights of each item to be selected from.</param>
        /// <param name="seededRandom">The random number generator to use.</param>
        public WeightedRandom(List<int> weights, Random seededRandom)
        {
            this.Weights = weights;
            this.RNG = seededRandom;

            int length = this.Weights.Count;
            for (int i = 0; i < length; i++)
            {
                this.TotalWeight += this.Weights[i];
            }
        }

        /// <summary>
        /// Returns the index of the selected item.
        /// </summary>
        /// <returns></returns>
        public int GetNext()
        {
            int rn = this.RNG.Next(0, this.TotalWeight);
            int currentWeightSum = 0;

            int i = 0;
            while (currentWeightSum < rn)
            {
                currentWeightSum += this.Weights[i];

                if (currentWeightSum >= rn)
                {
                    break;
                }

                i++;
            }

            return i;
        }
    }
}