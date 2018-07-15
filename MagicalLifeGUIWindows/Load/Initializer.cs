using MagicalLifeAPI.Load;
using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeGUIWindows.Input.Specialized_Handlers;

namespace MagicalLifeGUIWindows.Load
{
    public class Initializer : IGameLoader
    {
        public void InitialStartup()
        {
            InputHistory.Initialize();
            InputHandlers.Initialize();
        }
    }
}