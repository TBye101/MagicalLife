using MagicalLifeAPI.Server;
using MagicalLifeDedicatedServer.API.Commands;
using System.Collections.Generic;

namespace MagicalLifeDedicatedServer.API
{
    public class InternalCommandModule : ICommandModule
    {
        public List<ICommand> getCommands()
        {
            return new List<ICommand>()
            {
                new NewGame(),
                new StartGame(),
                new SaveGame()
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