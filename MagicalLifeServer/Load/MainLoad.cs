using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.World;
using MagicalLifeServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.Load
{
    /// <summary>
    /// Does some loading for the server.
    /// </summary>
    public class MainLoad : IGameLoader
    {
        public int GetTotalOperations()
        {
            return 1;
        }

        public void InitialStartup(ref int progress)
        {
            World.WorldGenerated += this.MainWorld_WorldGenerated;
            progress++;
        }

        private void MainWorld_WorldGenerated(object sender, MagicalLifeAPI.World.WorldEventArgs e)
        {
            ServerSendRecieve.SendAll<WorldTransferMessage>(new WorldTransferMessage(e.World));
        }
    }
}
