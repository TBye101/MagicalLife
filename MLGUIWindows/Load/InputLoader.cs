using MLAPI.Load;
using MonoGUI.MonoGUI.Input;

namespace MLGUIWindows.Load
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