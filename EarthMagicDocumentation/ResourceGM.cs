// <copyright file="ResourceGM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicDocumentation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Facilitates in the fetching of resources.
    /// </summary>
    public static class ResourceGM
    {
        /// <summary>
        /// Returns a string list of the file specified.
        /// </summary>
        /// <param name="path">Ex: Namespace.Folder.Folder.File.Extension</param>
        /// <returns></returns>
        public static List<string> GetResource(string path)
        {
            Assembly docAsm = typeof(ResourceGM).GetTypeInfo().Assembly;

            Stream resource = docAsm.GetManifestResourceStream(path);

            if (resource == null)
            {
                resource = docAsm.GetManifestResourceStream("EarthMagicDocumentation.ASCII_Art.Error.txt");
                if (resource == null)
                {
                    Console.WriteLine("A critical error has occurred in resource loading.");
                    return new List<string>();
                }
            }

            StreamReader reader = new StreamReader(resource);

            List<string> ret = new List<string>();
            while (!reader.EndOfStream)
            {
                ret.Add(reader.ReadLine());
            }

            return ret;
        }
    }
}