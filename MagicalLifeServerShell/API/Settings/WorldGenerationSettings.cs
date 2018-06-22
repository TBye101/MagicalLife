using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServerShell.API.Settings
{
    /// <summary>
    /// Holds some settings that determines how the next generated world will turn out.
    /// </summary>
    public class WorldGenerationSettings
    {
        public int DimensionWidth { get; set; }

        public int DimensionHeight { get; set; }

        public WorldGenerationSettings(bool isDefault)
        {
            this.DimensionWidth = 1;
            this.DimensionHeight = 1;
        }

        public WorldGenerationSettings()
        {

        }
    }
}
