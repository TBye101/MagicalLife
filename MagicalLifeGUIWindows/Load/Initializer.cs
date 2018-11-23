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
            if (MagicalLifeSettingsCore.Storage.Player.Default.PlayerID == Guid.Empty)
            {
                MagicalLifeSettingsCore.Storage.Player.Default.PlayerID = Guid.NewGuid();
            }

            InputHistory.Initialize();
            InputHandlers.Initialize();
            SettingsManager.Initialize();
            MusicPlayer.Init();
        }
    }
}