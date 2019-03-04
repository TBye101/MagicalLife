using MagicalLifeAPI.Filing.Settings;
using System.IO;

namespace MagicalLifeAPI.Filing
{
    /// <summary>
    /// Holds all of the settings in the game, except for the dedicated server specific settings.
    /// </summary>
    public static class SettingsManager
    {
        internal static Setting<AudioSettings> AudioSettings { get; set; }

        internal static Setting<Keybindings> Keybindings { get; set; }

        internal static Setting<MainWindowSettings> WindowSettings { get; set; }

        internal static Setting<PlayerSettings> PlayerSettings { get; set; }

        internal static Setting<UniversalSettings> UniversalSettings { get; set; }

        private static readonly string SettingFolder = FileSystemManager.RootDirectory + Path.DirectorySeparatorChar + "Config";

        internal static void Initialize()
        {
            Directory.CreateDirectory(SettingFolder);
            AudioSettings = new Setting<AudioSettings>(SettingFolder + Path.DirectorySeparatorChar + "Audio.json", new Settings.AudioSettings());
            Keybindings = new Setting<Keybindings>(SettingFolder + Path.DirectorySeparatorChar + "Keybindings.json", new Settings.Keybindings());
            WindowSettings = new Setting<MainWindowSettings>(SettingFolder + Path.DirectorySeparatorChar + "Window.json", new MainWindowSettings());
            PlayerSettings = new Setting<PlayerSettings>(SettingFolder + Path.DirectorySeparatorChar + "Player.json", new Settings.PlayerSettings());
            UniversalSettings = new Setting<UniversalSettings>(SettingFolder + Path.DirectorySeparatorChar + "Universal.json", new Settings.UniversalSettings());
        }
    }
}