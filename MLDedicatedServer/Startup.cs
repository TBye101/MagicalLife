using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Error;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.World.Data;
using MagicalLifeDedicatedServer.API;

namespace MagicalLifeDedicatedServer
{
    /// <summary>
    /// Does some startup logic.
    /// </summary>
    public static class Startup
    {
        public static void Go()
        {
            World.Mode = MagicalLifeAPI.Networking.EngineMode.ServerOnly;
            AssetManager.IsServerOnly = true;
            FileSystemManager.Initialize();
            MasterLog.Initialize();
            ErrorReporter.Initialize();
            SettingsHandler.Initialize();
        }
    }
}