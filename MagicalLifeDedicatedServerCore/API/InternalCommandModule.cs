using MagicalLifeAPI.Server;
using MagicalLifeDedicatedServer.API.Commands;
using System.Collections.Generic;

namespace MagicalLifeDedicatedServer.API
{
    public class InternalCommandModule : ICommandModule
    {
        public List<ICommand> GetCommands()
        {
            return new List<ICommand>()
            {
                new NewGame(),
                new StartGame(),
                new SaveGame()
            };
        }

        public string GetCommandUsageName()
        {
            return "ml";
        }

        public string GetFullName()
        {
            return "Magical Life";
        }
    }
}