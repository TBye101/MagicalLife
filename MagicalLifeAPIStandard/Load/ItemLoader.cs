using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Items;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Load
{
    internal class ItemLoader : IGameLoader
    {
        public void InitialStartup()
        {
            ItemRegistry.Initialize(new List<Type>()
            {
                typeof(StoneRubble),
                typeof(Log)
            });
        }
    }
}