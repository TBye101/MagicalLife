using System;

namespace MLAPI.Util
{
    /// <summary>
    /// Some basic array utilities.
    /// </summary>
    public static class ArrayUtil
    {
        /// <summary>
        /// Sets all values in the array to equal the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="value"></param>
        public static void FillAll<T>(T[,] array, T value)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    array[x, y] = value;
                }
            }
        }

        /// <summary>
        /// Fills an array with numbers in order from the inclusive minimum to the exlusive maximum.
        /// </summary>
        public static int[] FillNumericalRange(int inclusiveMin, int exclusiveMax)
        {
            int[] numbers = new int[exclusiveMax - inclusiveMin];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = inclusiveMin + i;
            }

            return numbers;
        }

        /// <summary>
        /// Swaps elements between the two arrays from the inclusive start point to the exclusive end point.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="inclusiveStart"></param>
        /// <param name="exclusiveStop"></param>
        public static void SwapBetweenArrays<T>(T[] a, T[] b, int inclusiveStart, int exclusiveStop)
        {
            if (a.Length < exclusiveStop || b.Length < exclusiveStop)
            {
                throw new InvalidOperationException("Swapping would go out of bounds in at least one array");
            }

            for (int i = inclusiveStart; i < exclusiveStop; i++)
            {
                T temp = a[i];
                a[i] = b[i];
                b[i] = temp;
            }
        }
    }
}