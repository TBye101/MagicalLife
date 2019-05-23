using MagicalLifeAPI.Server;
using MagicalLifeDedicatedServer.Properties;
using MagicalLifeServer;
using System.Collections.Generic;

namespace MagicalLifeDedicatedServer.API.Commands
{
    public class StartGame : ICommand
    {
        public string GetHelp()
        {
            return DedicatedServer.StartGameCommandDesc;
        }

        public string GetName()
        {
            return "Startgame";
        }

        public void Run(List<string> input)
        {
            Server.StartGame();
            Util.WriteLine(DedicatedServer.GameStarted);
        }
    }
}