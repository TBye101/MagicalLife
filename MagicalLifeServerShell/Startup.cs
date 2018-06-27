using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeServerShell.API.Settings;

namespace MagicalLifeServerShell
{
    /// <summary>
    /// Does some startup logic.
    /// </summary>
    public static class Startup
    {
        public static void Go()
        {
            AssetManager.isServerOnly = true;
            FileSystemManager.Initialize();
            MasterLog.Initialize();
            SettingsHandler.Initialize();
        }
    }
}