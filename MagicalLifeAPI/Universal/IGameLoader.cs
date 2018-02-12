namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// Implemented by anything that does initial startup code.
    /// </summary>
    public interface IGameLoader
    {
        /// <summary>
        /// Returns the number of jobs to do for the object to be done with it's startup logic.
        /// </summary>
        /// <returns></returns>
        int GetTotalOperations();

        /// <summary>
        /// This method is called to initiate the loading code for the object.
        /// </summary>
        /// <param name="progress">A integer that should be updated after each job is done within the loading code.</param>
        void InitialStartup(ref int progress);
    }
}