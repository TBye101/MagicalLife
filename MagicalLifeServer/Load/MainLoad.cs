using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using MagicalLifeServer.Networking;
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
            return 2;
        }

        public void InitialStartup(ref int progress)
        {
            World.DimensionGenerated += this.World_DimensionGenerated;
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