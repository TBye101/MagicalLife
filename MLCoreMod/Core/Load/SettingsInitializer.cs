using MLAPI.Load;
using MLCoreMod.Core.Settings;

namespace MLCoreMod.Core.Load
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