using MagicalLifeAPI.Load;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeMod.Core.Load
{
    /// <summary>
    /// Registers the items.
    /// </summary>
    public class ItemRegisterer : IGameLoader
    {
        public void InitialStartup()
        {
            ItemRegistry.RegisterItemType(new Log(1));
            ItemRegistry.RegisterItemType(new StoneRubble(1));
        }
    }
}
