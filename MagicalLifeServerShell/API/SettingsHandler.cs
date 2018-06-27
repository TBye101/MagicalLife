using MagicalLifeAPI.Filing;
using System.IO;

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
        public static ServerSetting<ServerNetworkSettings> NetworkSettings;

        /// <summary>
        /// World generation settings.
        /// </summary>
        public static ServerSetting<WorldGenerationSettings> WorldGenerationSettings;

        private static string ServerSettingsDirectory;

        public static void Initialize()
        {
            ServerSettingsDirectory = Directory.CreateDirectory(FileSystemManager.RootDirectory + Path.DirectorySeparatorChar + "Dedicated_Settings").FullName;

            NetworkSettings = new ServerSetting<ServerNetworkSettings>(ServerSettingsDirectory + Path.DirectorySeparatorChar + "Network.json", new Settings.ServerNetworkSettings(true));
            WorldGenerationSettings = new ServerSetting<WorldGenerationSettings>(ServerSettingsDirectory + Path.DirectorySeparatorChar + "WorldGeneration.json", new Settings.WorldGenerationSettings(true));
        }
    }
}