namespace EarthWithMagicAPI.API.Util
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;

    public class Filing
    {
        static Filing()
        {
            Initialize();
        }

        /// <summary>
        /// The path to the current instance folder.
        /// </summary>
        private static string rootFolder;

        private static StreamWriter log;

        public static string RootFolder
        {
            get
            {
                return rootFolder;
            }

            set
            {
                rootFolder = value;
            }
        }

        /// <summary>
        /// Does some setup work.
        /// </summary>
        private static void Initialize()
        {
            SetupRootFolder();
            InitializeLog();
        }

        /// <summary>
        /// Sets up the log.
        /// </summary>
        private static void InitializeLog()
        {
            log = new StreamWriter(RootFolder + Path.DirectorySeparatorChar + "log.txt", true);
        }

        /// <summary>
        /// Sets up the root folder for our program.
        /// </summary>
        private static void SetupRootFolder()
        {
            RootFolder = Assembly.GetExecutingAssembly().Location;
            RootFolder = Path.GetDirectoryName(RootFolder);
            RootFolder += Path.DirectorySeparatorChar;
            RootFolder += "Dungeons of Earth";
            Directory.CreateDirectory(RootFolder);
            RootFolder += Path.DirectorySeparatorChar;
            RootFolder += "Instances";
            Directory.CreateDirectory(RootFolder);
            RootFolder += Path.DirectorySeparatorChar;
            RootFolder += GetIOSafeTime();
            Directory.CreateDirectory(RootFolder);
        }

        /// <summary>
        /// Returns a IO (file and directory) safe time.
        /// </summary>
        /// <returns></returns>
        private static string GetIOSafeTime()
        {
            return string.Format(
                "{0:[yyyy-MM-dd][hh-mm-ss-tt}]",
            DateTime.Now);
        }

        /// <summary>
        /// Reads a line from the console, and makes sure it ends up in the log.
        /// </summary>
        /// <returns></returns>
        public static string ReadLine()
        {
            string ret = Console.ReadLine();
            log.WriteLine(ret);

            return ret;
        }

        /// <summary>
        /// Writes a line to the log.
        /// </summary>
        /// <param name="msg"></param>
        public static void Writeline(string msg)
        {
            string toWrite = GetIOSafeTime() + " " + msg;
            log.WriteLine(toWrite);
            Console.WriteLine(toWrite);
            log.Flush();
        }
    }
}
