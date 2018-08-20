using MagicalLifeAPI.Asset;
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
            AssetManager.isServerOnly = true;
            FileSystemManager.Initialize();
            MasterLog.Initialize();
            SettingsHandler.Initialize();//Fix menu system, after making auto save capability
        }
    }
}