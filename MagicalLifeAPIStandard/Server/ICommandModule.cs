using System.Collections.Generic;

namespace MagicalLifeAPI.Server
{
    /// <summary>
    /// For each package to implement once and have each command within.
    /// </summary>
    public interface ICommandModule
    {
        /// <summary>
        /// All commands contained within this command module.
        /// </summary>
        List<ICommand> GetCommands();

        /// <summary>
        /// The name that must be used in front of each command to qualify that the command is meant for this module.
        /// Ex: interact help
        /// Would execute the command "help" in the module "interact" if it existed.
        /// </summary>
        string GetCommandUsageName();

        /// <summary>
        /// The display name of this command module.
        /// </summary>
        string GetFullName();
    }
}