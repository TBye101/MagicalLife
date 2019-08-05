using MLAPI.Asset;
using MLAPI.Error;
using MLAPI.Filing;
using MLAPI.Filing.Logging;
using MLAPI.Networking;
using MLAPI.World.Data;
using MLDedicatedServer.API;

namespace MLDedicatedServer
{
    /// <summary>
    /// Does some startup logic.
    /// </summary>
    public static class Startup
    {
        public static void Go()
        {
            World.Mode = EngineMode.ServerOnly;
            AssetManager.IsServerOnly = true;
            FileSystemManager.Initialize();
            MasterLog.Initialize();
            ErrorReporter.Initialize();
            SettingsHandler.Initialize();
        }
    }
}