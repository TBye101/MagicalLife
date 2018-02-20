using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Filing
{
    /// <summary>
    /// Manages file system operations.
    /// </summary>
    public static class FileSystemManager
    {
        /// <summary>
        /// The path to the current instance folder.
        /// </summary>
        public static string rootFolder;

        public static void Initialize()
        {
            SetupRootFolder();
        }

        /// <summary>
        /// Sets up the root folder for our program.
        /// </summary>
        private static void SetupRootFolder()
        {
            rootFolder = Assembly.GetExecutingAssembly().Location;
            rootFolder = Path.GetDirectoryName(rootFolder);
            rootFolder += Path.DirectorySeparatorChar;
            rootFolder += "EarthWithMagic";
            Directory.CreateDirectory(rootFolder);
            rootFolder += Path.DirectorySeparatorChar;
            rootFolder += "Instances";
            Directory.CreateDirectory(rootFolder);
            rootFolder += Path.DirectorySeparatorChar;
            rootFolder += GetIOSafeTime();
            Directory.CreateDirectory(rootFolder);
        }

        /// <summary>
        /// Returns a IO (file and directory) safe time.
        /// </summary>
        /// <returns></returns>
        private static string GetIOSafeTime()
        {
            return string.Format("{0:[yyyy-MM-dd][hh-mm-ss-tt}]",
            DateTime.Now);
        }

    }
}
