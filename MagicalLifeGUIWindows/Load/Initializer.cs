using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.Input;
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
            return 1;
        }

        public void InitialStartup(ref int progress)
        {
            InputHistory.Initialize();
            progress++;
        }
    }
}
