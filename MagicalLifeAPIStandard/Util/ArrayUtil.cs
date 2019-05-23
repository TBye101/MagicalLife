namespace MagicalLifeAPI.Util
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
    }
}