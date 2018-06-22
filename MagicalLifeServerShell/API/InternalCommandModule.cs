using MagicalLifeServerShell.API.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServerShell.API
{
    public class InternalCommandModule : ICommandModule
    {
        public List<ICommand> getCommands()
        {
            return new List<ICommand>()
            {
                new NewGame()
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
