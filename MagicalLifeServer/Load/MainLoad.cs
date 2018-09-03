using MagicalLifeAPI.Load;
using MagicalLifeAPI.World.Data;
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
            World.DimensionAdded += this.World_DimensionGenerated;
            ServerProcessor.Initialize();
        }

        private void World_DimensionGenerated(object sender, int e)
        {
        }
    }
}