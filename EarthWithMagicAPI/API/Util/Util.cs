namespace EarthWithMagicAPI.API.Util
{
    using System;
    using System.Collections.Generic;

    public static class Util
    {
        /// <summary>
        /// Writes a line to the console.
        /// </summary>
        /// <param name="message"></param>
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteLine(List<string> message)
        {
            foreach (string item in message)
            {
                Console.WriteLine(item);
            }
        }
    }
}