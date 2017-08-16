using Microsoft.VisualBasic.CompilerServices;
using System.IO;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthMagicDocumentation
{
    /// <summary>
    /// Facilitates in the fetching of resources.
    /// </summary>
    public static class ResourceGM
    {
        /// <summary>
        /// Returns a string list of the file specified.
        /// </summary>
        /// <param name="Path">Ex: Namespace.Folder.Folder.File.Extension</param>
        /// <returns></returns>
        public static List<string> GetResource(string Path)
        {
            Assembly docAsm = typeof(ResourceGM).GetTypeInfo().Assembly;

            //foreach (string item in docAsm.GetManifestResourceNames())
            //{
            //    Console.Write(item + "\r\n");
            //}

            Stream resource = docAsm.GetManifestResourceStream(Path);
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
