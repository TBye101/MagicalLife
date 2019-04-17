using MagicalLifeAPI.Server;
using MagicalLifeDedicatedServer.Properties;
using MagicalLifeServer;
using System.Collections.Generic;

namespace MagicalLifeDedicatedServer.API.Commands
{
    public class StartGame : ICommand
    {
        public string getHelp()
        {
            return DedicatedServer.StartGameCommandDesc;
        }

        public string getName()
        {
            return "Startgame";
        }

        public void run(List<string> input)
        {
            Server.StartGame();
            Util.WriteLine(DedicatedServer.GameStarted);
        }
    }
}