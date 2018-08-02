using MagicalLifeDedicatedServer.API.Commands;
using MagicalLifeServerShell.API.Commands;
using System.Collections.Generic;

namespace MagicalLifeServerShell.API
{
    public class InternalCommandModule : ICommandModule
    {
        public List<ICommand> getCommands()
        {
            return new List<ICommand>()
            {
                new NewGame(),
                new StartGame()
            };
        }

        public string getCommandUsageName()
        {
            return "ml";
        }

        public string getFullName()
        {
            return "Magical Life";
        }
    }
}