using MagicalLifeAPI.Filing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServerShell.API.Settings
{
    /// <summary>
    /// Handles all settings for the dedicated server.
    /// </summary>
    public static class SettingsHandler
    {
        /// <summary>
        /// Network settings.
        /// </summary>
        private static ServerSetting<NetworkSettings> NetworkSettings;

        private static string ServerSettingsDirectory;

        public static void Initialize()
        {
            ServerSettingsDirectory = Directory.CreateDirectory(FileSystemManager.RootDirectory + Path.DirectorySeparatorChar + "Dedicated_Settings").FullName;

            NetworkSettings = new ServerSetting<NetworkSettings>(ServerSettingsDirectory + Path.DirectorySeparatorChar + "NetworkSettings.json", new Settings.NetworkSettings(true));
        }
    }
}
