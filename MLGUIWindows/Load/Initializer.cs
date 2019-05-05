using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.Input;
using MagicalLifeGUIWindows.Input.History;
using System;

namespace MagicalLifeGUIWindows.Load
{
    public class Initializer : IGameLoader
    {
        public void InitialStartup()
        {
            SettingsManager.Initialize();

            if (SettingsManager.PlayerSettings.Settings.PlayerID == Guid.Empty)
            {
                SettingsManager.PlayerSettings.Settings.PlayerID = Guid.NewGuid();
            }

            InputHistory.Initialize();
            InputHandlers.Initialize();
            MusicPlayer.Init();
            this.SaveSettings();
        }

        /// <summary>
        /// Save settings after setting initialization so that any first time setting initialization is saved.
        /// </summary>
        private void SaveSettings()
        {
            SettingsManager.AudioSettings.Save();
            SettingsManager.Keybindings.Save();
            SettingsManager.PlayerSettings.Save();
            SettingsManager.UniversalSettings.Save();
            SettingsManager.WindowSettings.Save();
        }
    }
}