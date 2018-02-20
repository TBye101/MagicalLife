using MagicalLifeRenderEngine.Main.GUI.Click;
using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
