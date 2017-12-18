// <copyright file="Util.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
            Filing.Writeline(message);
        }

        public static void WriteLine(List<string> message)
        {
            foreach (string item in message)
            {
                Filing.Writeline(item);
            }
        }
    }
}