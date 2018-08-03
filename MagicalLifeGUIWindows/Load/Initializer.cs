using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeGUIWindows.Input.Specialized;
using System;

namespace MagicalLifeGUIWindows.Load
{
    public class Initializer : IGameLoader
    {
        public void InitialStartup()
        {
            if (MagicalLifeSettings.Storage.Player.Default.PlayerID == Guid.Empty)
            {
                MagicalLifeSettings.Storage.Player.Default.PlayerID = Guid.NewGuid();
            }

            InputHistory.Initialize();
            InputHandlers.Initialize();
            SettingsManager.Initialize();
            MusicPlayer.Init();
        }
    }
}