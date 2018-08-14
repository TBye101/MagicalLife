using MagicalLifeAPI.Settings;
using System.IO;

namespace MagicalLifeAPI.Filing
{
    /// <summary>
    /// Holds all of the settings in the game, except for the dedicated server specific settings.
    /// </summary>
    public static class SettingsManager
    {
        public static Setting<AudioSettings> AudioSettings { get; set; }

        private static readonly string SettingFolder = FileSystemManager.RootDirectory + Path.DirectorySeparatorChar + "Config";

        public static void Initialize()
        {
            Directory.CreateDirectory(SettingFolder);
            AudioSettings = new Setting<AudioSettings>(SettingFolder + Path.DirectorySeparatorChar + "Audio.json", new Settings.AudioSettings());
        }
    }
}