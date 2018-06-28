using MagicalLifeAPI.Universal;
using MagicalLifeAPI.World.Data;
using MagicalLifeServer.Processing;

namespace MagicalLifeServer.Load
{
    /// <summary>
    /// Does some loading for the server.
    /// </summary>
    public class MainLoad : IGameLoader
    {
        public int GetTotalOperations()
        {
            return 3;
        }

        public void InitialStartup(ref int progress)
        {
            World.DimensionAdded += this.World_DimensionGenerated;
            progress++;
            ServerProcessor.Initialize();
            progress++;
        }

        private void World_DimensionGenerated(object sender, int e)
        {
            //ServerSendRecieve.SendAll<WorldTransferMessage>(new WorldTransferMessage());
        }
    }
}