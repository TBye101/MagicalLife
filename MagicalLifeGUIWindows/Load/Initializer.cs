using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.Input;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeGUIWindows.Input.Specialized_Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Load
{
    public class Initializer : IGameLoader
    {
        public int GetTotalOperations()
        {
            return 2;
        }

        public void InitialStartup(ref int progress)
        {
            InputHistory.Initialize();
            progress++;
            InputHandlers.Initialize();
            progress++;
        }
    }
}
