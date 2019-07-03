using MagicalLifeAPI.Load;
using MagicalLifeServer.Processing;

namespace MagicalLifeServer.Load
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