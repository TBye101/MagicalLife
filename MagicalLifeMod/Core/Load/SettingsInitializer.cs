using MagicalLifeAPI.Load;
using MagicalLifeMod.Core.Settings;

namespace MagicalLifeMod.Core.Load
{
    /// <summary>
    /// Initializes the settings for this core mod.
    /// </summary>
    public class SettingsInitializer : IGameLoader
    {
        public void InitialStartup()
        {
            CoreSettingsHandler.Initialize();
        }
    }
}