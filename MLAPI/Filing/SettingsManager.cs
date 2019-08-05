using System.IO;
using MLAPI.Filing.Settings;

namespace MLAPI.Filing
{
    /// <summary>
    /// Holds all of the settings in the game, except for the dedicated server specific settings.
    /// </summary>
    public static class SettingsManager
    {
        public static Setting<AudioSettings> AudioSettings { get; internal set; }

        public static Setting<Keybindings> Keybindings { get; set; }

        public static Setting<MainWindowSettings> WindowSettings { get; internal set; }

        public static Setting<PlayerSettings> PlayerSettings { get; internal set; }

        public static Setting<UniversalSettings> UniversalSettings { get; internal set; }

        private static readonly string SettingFolder = FileSystemManager.RootDirectory + Path.DirectorySeparatorChar + "Config";

        internal static void Initialize()
        {
            Directory.CreateDirectory(SettingFolder);
            AudioSettings = new Setting<AudioSettings>(SettingFolder + Path.DirectorySeparatorChar + "Audio.json", new AudioSettings());
            Keybindings = new Setting<Keybindings>(SettingFolder + Path.DirectorySeparatorChar + "Keybindings.json", new Keybindings());
            WindowSettings = new Setting<MainWindowSettings>(SettingFolder + Path.DirectorySeparatorChar + "Window.json", new MainWindowSettings());
            PlayerSettings = new Setting<PlayerSettings>(SettingFolder + Path.DirectorySeparatorChar + "Player.json", new PlayerSettings());
            UniversalSettings = new Setting<UniversalSettings>(SettingFolder + Path.DirectorySeparatorChar + "Universal.json", new UniversalSettings());
        }
    }
}