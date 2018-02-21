using MagicalLifeAPI.Universal;
using MagicalLifeRenderEngine.Main.GUI.Click;

namespace MagicalLifeGUIWindows.Load
{
    /// <summary>
    /// Initializes some input related things.
    /// </summary>
    public class InputLoader : IGameLoader
    {
        public int GetTotalOperations()
        {
            return 1;
        }

        public void InitialStartup(ref int progress)
        {
            MouseHandler.Initialize();
            progress++;
        }
    }
}