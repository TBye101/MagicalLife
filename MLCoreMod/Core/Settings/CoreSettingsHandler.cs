using System.IO;
using MLAPI.Filing;

namespace MLCoreMod.Core.Settings
{
    /// <summary>
    /// Handles the settings for the core mod.
    /// </summary>
    public static class CoreSettingsHandler
    {
        public static Setting<DefaultGenerationSettings> GenerationSettings { get; set; }
        public static Setting<StructurePartConfig> PartConfig { get; set; }
        public static Setting<DungeonGenConfig> DungeonGenerationConfig { get; set; }

        private static readonly string CoreSettingsFolder = FileSystemManager.RootDirectory + Path.DirectorySeparatorChar + "Config" + Path.DirectorySeparatorChar + "MagicalLifeCore";

        internal static void Initialize()
        {
            Directory.CreateDirectory(CoreSettingsFolder);
            GenerationSettings = new Setting<DefaultGenerationSettings>(CoreSettingsFolder + Path.DirectorySeparatorChar + "WorldGenerationDefault.json", new DefaultGenerationSettings());
            PartConfig = new Setting<StructurePartConfig>(CoreSettingsFolder + Path.DirectorySeparatorChar + "StructureParts.json", new StructurePartConfig());
            DungeonGenerationConfig = new Setting<DungeonGenConfig>(CoreSettingsFolder + Path.DirectorySeparatorChar + "DungeonGenerationConfig.json", new DungeonGenConfig());
        }
    }
}