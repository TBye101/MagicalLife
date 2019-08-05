using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.Error.InternalExceptions;

namespace MLAPI.Util.RandomUtils
{
    /// <summary>
    /// Used to select random elements while guarenteeing no duplicates. 
    /// </summary>
    public class NonDuplicateElementSelector<T>
    {
        /// <summary>
        /// The values within the working numeric range.
        /// </summary>
        private IList<T> ElementRange { get; set; }

        /// <summary>
        /// The index of where the discard/previously used numbers begin.
        /// </summary>
        private int DiscardedIndex { get; set; }

        private Random RNG { get; set; }

        /// <summary>
        /// The number of elements left before this must be reset.
        /// </summary>
        public int ElementLeft
        {
            get
            {
                return this.DiscardedIndex;
            }
        }

        public NonDuplicateElementSelector(IList<T> elements)
        {
            this.ElementRange = elements;
            this.RNG = new Random();
            this.Shuffle(this.ElementRange);
            this.DiscardedIndex = this.ElementRange.Count;
        }

        public T GetRandomElement()
        {
            if (this.DiscardedIndex == 0)
            {
                throw new UnexpectedStateException("Too many random elements were requested, not enough non duplicate values within the specified range exist");
            }

            int index = this.RNG.Next(0, this.DiscardedIndex);
            T element = this.ElementRange[index];

            this.DiscardedIndex--;
            this.ElementRange[index] = this.ElementRange[this.DiscardedIndex];
            this.ElementRange[this.DiscardedIndex] = element;

            return element;
        }

        /// <summary>
        /// Resets this generator, allowing all values to be generated again.
        /// </summary>
        public void Reset()
        {
            this.DiscardedIndex = this.ElementRange.Count;
            this.Shuffle(this.ElementRange);
        }


        private void Shuffle(IList<T> numericRange)
        {
            for (int i = 0; i < numericRange.Count; i++)
            {
                int j = this.RNG.Next(0, i + 1);
                T swap = numericRange[i];
                numericRange[i] = numericRange[j];
                numericRange[j] = swap;
            }
        }
    }
}
