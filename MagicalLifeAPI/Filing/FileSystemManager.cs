using System;
using System.IO;
using System.Reflection;

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
        public static string instanceRootFolder;

        /// <summary>
        /// The directory the main executable is in.
        /// </summary>
        public static string RootDirectory;

        public static void Initialize()
        {
            SetupRootFolder();
        }

        /// <summary>
        /// Sets up the root folder for our program.
        /// </summary>
        private static void SetupRootFolder()
        {
            instanceRootFolder = Assembly.GetExecutingAssembly().Location;
            instanceRootFolder = Path.GetDirectoryName(instanceRootFolder);
            RootDirectory = instanceRootFolder;
            instanceRootFolder += Path.DirectorySeparatorChar;
            instanceRootFolder += "Logging";
            Directory.CreateDirectory(instanceRootFolder);
            instanceRootFolder += Path.DirectorySeparatorChar;
            instanceRootFolder += "Instances";
            Directory.CreateDirectory(instanceRootFolder);
            instanceRootFolder += Path.DirectorySeparatorChar;
            instanceRootFolder += GetIOSafeTime();
            Directory.CreateDirectory(instanceRootFolder);
        }

        /// <summary>
        /// Returns a IO (file and directory) safe time.
        /// </summary>
        /// <returns></returns>
        public static string GetIOSafeTime()
        {
            return string.Format("{0:[yyyy-MM-dd][hh-mm-ss-tt}]",
            DateTime.Now);
        }
    }
}