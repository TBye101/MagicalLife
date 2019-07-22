using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Util.RandomUtils
{
    /// <summary>
    /// Used to generate random numbers within a range while guarenteeing no duplicates. 
    /// </summary>
    public class NonDuplicateRandomRange
    {
        private int Min { get; set; }

        /// <summary>
        /// The values within the working numeric range.
        /// </summary>
        private int[] NumericRange { get; set; }

        /// <summary>
        /// The index of where the discard/previously used numbers begin.
        /// </summary>
        private int DiscardedIndex { get; set; }

        private Random RNG { get; set; }

        public NonDuplicateRandomRange(int inclusiveMin, int exclusiveMax)
        {
            this.Min = inclusiveMin;
            this.RNG = new Random();
            this.NumericRange = ArrayUtil.FillNumericalRange(inclusiveMin, exclusiveMax);
            this.Shuffle(this.NumericRange);
            this.DiscardedIndex = this.NumericRange.Length;
        }

        public int GetRandomNumber()
        {
            if (this.DiscardedIndex == 0)
            {
                throw new UnexpectedStateException("Too many random numbers were requested, not enough non duplicate values within the specified range exist");
            }

            int index = this.RNG.Next(this.Min, this.DiscardedIndex);
            int number = this.NumericRange[index];

            this.DiscardedIndex--;
            this.NumericRange[index] = this.NumericRange[this.DiscardedIndex];
            this.NumericRange[this.DiscardedIndex] = number;

            return number;
        }

        /// <summary>
        /// Resets this generator, allowing all values to be generated again.
        /// </summary>
        public void Reset()
        {
            this.DiscardedIndex = this.NumericRange.Length;
            this.Shuffle(this.NumericRange);
        }
        

        private void Shuffle(int[] numericRange)
        {
            for (int i = 0; i < numericRange.Length; i++)
            {
                int j = this.RNG.Next(0, i + 1);
                int swap = numericRange[i];
                numericRange[i] = numericRange[j];
                numericRange[j] = swap;
            }
        }
    }
}
