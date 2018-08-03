using MagicalLifeAPI.Server;
using MagicalLifeServer;
using System.Collections.Generic;

namespace MagicalLifeDedicatedServer.API.Commands
{
    public class StartGame : ICommand
    {
        public string getHelp()
        {
            return "Starts the game";
        }

        public string getName()
        {
            return "startgame";
        }

        public void run(List<string> input)
        {
            Server.StartGame();
            Util.WriteLine("Game started!");
        }
    }
}