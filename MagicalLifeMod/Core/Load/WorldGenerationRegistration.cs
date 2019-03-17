using MagicalLifeAPI.Load;
using MagicalLifeAPI.Registry.WorldGeneration;
using MagicalLifeMod.Core.WorldGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeMod.Core.Load
{
    /// <summary>
    /// Registers all world generators with the world registry.
    /// </summary>
    public class WorldGenerationRegistration : IGameLoader
    {
        public void InitialStartup()
        {
            WorldGeneratorRegistry.Generators.Add(new GenerationAllocator());
        }
    }
}
