namespace MagicalLifeAPI.Load
{
    /// <summary>
    /// Implemented by anything that does initial startup code.
    /// </summary>
    internal interface IGameLoader
    {
        /// <summary>
        /// This method is called to initiate the loading code for the object.
        /// </summary>
        /// <param name="progress">A integer that should be updated after each job is done within the loading code.</param>
        void InitialStartup();
    }
}