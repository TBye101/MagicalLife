using MLAPI.Load;
using MLServer.Processing;

namespace MLServer.Load
{
    /// <summary>
    /// Does some loading for the server.
    /// </summary>
    public class MainLoad : IGameLoader
    {
        public void InitialStartup()
        {
            ServerProcessor.Initialize();
        }
    }
}