using System.Collections.Generic;

namespace MagicalLifeServerShell
{
    /// <summary>
    /// A command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the name of this command.
        /// </summary>
        /// <returns></returns>
        string getName();

        /// <summary>
        /// Tells this command to run with the specified input.
        /// This input doesn't contain the name of this command.
        /// </summary>
        /// <param name="input"></param>
        void run(List<string> input);

        /// <summary>
        /// Returns a string giving help information about this command.
        /// </summary>
        /// <returns></returns>
        string getHelp();
    }
}