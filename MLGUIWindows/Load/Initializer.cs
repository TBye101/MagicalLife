using System;
using MLAPI.Filing;
using MLAPI.Load;
using MLAPI.Sound;
using MLGUIWindows.Input;
using MonoGUI.MonoGUI.Input.History;

namespace MLGUIWindows.Load
{
    public class Initializer : IGameLoader
    {
        public void InitialStartup()
        {
            SettingsManager.Initialize();

            if (SettingsManager.PlayerSettings.Settings.PlayerId == Guid.Empty)
            {
                SettingsManager.PlayerSettings.Settings.PlayerId = Guid.NewGuid();
            }

            InputHistory.Initialize();
            InputHandlers.GameLoadInitialize();
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