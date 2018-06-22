using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeServerShell.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServerShell
{
    /// <summary>
    /// Does some startup logic.
    /// </summary>
    public static class Startup
    {
        public static void Go()
        {
            FileSystemManager.Initialize();
            MasterLog.Initialize();
            SettingsHandler.Initialize();
        }
    }
}
