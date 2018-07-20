using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeGUIWindows.Input.Specialized_Handlers;

namespace MagicalLifeGUIWindows.Load
{
    public class Initializer : IGameLoader
    {
        public void InitialStartup()
        {
            InputHistory.Initialize();
            InputHandlers.Initialize();
            SettingsManager.Initialize();
            MusicPlayer.Init();
            EffectPlayer.Init();
        }
    }
}