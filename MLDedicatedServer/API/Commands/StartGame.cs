using System.Collections.Generic;
using MLAPI.Server;
using MLDedicatedServer.Properties;
using MLServer;

namespace MLDedicatedServer.API.Commands
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