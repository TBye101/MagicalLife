using MagicalLifeAPI.Load;
using MagicalLifeGUIWindows.Input;

namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// Initializes some input related things.
    /// </summary>
    public class InputLoader : IGameLoader
    {
        public void InitialStartup()
        {
            BoundHandler.Initialize();
            KeyboardHandler.Initialize();
        }
    }
}