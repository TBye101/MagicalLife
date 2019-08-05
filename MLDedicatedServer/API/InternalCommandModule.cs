using System.Collections.Generic;
using MLAPI.Server;
using MLDedicatedServer.API.Commands;
using MLDedicatedServer.Properties;

namespace MLDedicatedServer.API
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

        /// <summary>
        /// The display name of this command module.
        /// </summary>
        /// <returns></returns>
        public string GetFullName()
        {
            return DedicatedServer.MagicalLife;
        }
    }
}