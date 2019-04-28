using MagicalLifeAPI.Filing;
using MagicalLifeMod.Core.WorldGeneration.Default;
using System.IO;

namespace MagicalLifeMod.Core.Settings
{
    /// <summary>
    /// Handles the settings for the core mod.
    /// </summary>
    public static class CoreSettingsHandler
    {
        public static Setting<DefaultGenerationSettings> GenerationSettings { get; set; }

        private static readonly string CoreSettingsFolder = FileSystemManager.RootDirectory + Path.DirectorySeparatorChar + "Config" + Path.DirectorySeparatorChar + "MagicalLifeCore";

        internal static void Initialize()
        {
            Directory.CreateDirectory(CoreSettingsFolder);
            GenerationSettings = new Setting<DefaultGenerationSettings>(CoreSettingsFolder + Path.DirectorySeparatorChar + "WorldGenerationDefault.json", new DefaultGenerationSettings());
        }
    }
}