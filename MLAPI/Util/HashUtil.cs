namespace MagicalLifeAPI.Util
{
    /// <summary>
    /// Has various hashing functionality.
    /// </summary>
    public static class HashUtil
    {
        /// <summary>
        /// Used to hash an array of 9 or less int items, with valid int values ranging from 0-8.
        /// </summary>
        /// <returns></returns>
        public static int HashNumericArray(int[] enumValues)
        {
            int length = enumValues.Length;
            int ret = 1;

            for (int i = 0; i < length; i++)
            {
                ret += (int)((enumValues[i] + 1) * (System.Math.Pow(10, i)));
            }

            return ret;
        }
    }
}