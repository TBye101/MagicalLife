using MagicalLifeAPI.Server;
using MagicalLifeServer;
using System.Collections.Generic;

namespace MagicalLifeDedicatedServer.API.Commands
{
    public class StartGame : ICommand
    {
        public string GetHelp()
        {
            return "Starts the game";
        }

        public string GetName()
        {
            return "startgame";
        }

        public void Run(List<string> input)
        {
            Server.StartGame();
            Util.WriteLine("Game started!");
        }
    }
}