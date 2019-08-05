using System.IO;
using MLAPI.Filing;
using MLDedicatedServer.API.Settings;

namespace MLDedicatedServer.API
{
    /// <summary>
    /// Handles all settings for the dedicated server.
    /// </summary>
    public static class SettingsHandler
    {
        /// <summary>
        /// Network settings.
        /// </summary>
        public static Setting<ServerNetworkSettings> NetworkSettings;

        /// <summary>
        /// World generation settings.
        /// </summary>
        public static Setting<WorldGenerationSettings> WorldGenerationSettings;

        private static string ServerSettingsDirectory;

        public static void Initialize()
        {
            ServerSettingsDirectory = Directory.CreateDirectory(FileSystemManager.RootDirectory + Path.DirectorySeparatorChar + "Dedicated_Settings").FullName;

            NetworkSettings = new Setting<ServerNetworkSettings>(ServerSettingsDirectory + Path.DirectorySeparatorChar + "Network.json", new Settings.ServerNetworkSettings(true));
            WorldGenerationSettings = new Setting<WorldGenerationSettings>(ServerSettingsDirectory + Path.DirectorySeparatorChar + "WorldGeneration.json", new Settings.WorldGenerationSettings(true));
        }
    }
}