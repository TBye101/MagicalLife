using MagicalLifeServer;
using MagicalLifeServerShell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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