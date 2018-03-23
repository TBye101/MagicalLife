using MagicalLifeGUIWindows.Input;

namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// Initializes some input related things.
    /// </summary>
    public class InputLoader : IGameLoader
    {
        public int GetTotalOperations()
        {
            return 2;
        }

        public void InitialStartup(ref int progress)
        {
            BoundHandler.Initialize();
            progress++;
            KeyboardHandler.Initialize();
            progress++;
        }
    }
}