using MagicalLifeAPI.Load;
using MagicalLifeMod.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeMod.Core.Load
{
    /// <summary>
    /// Initializes the settings for this core mod.
    /// </summary>
    public class SettingsInitializer : IGameLoader
    {
        public void InitialStartup()
        {
            CoreSettingsHandler.Initialize();
        }
    }
}
