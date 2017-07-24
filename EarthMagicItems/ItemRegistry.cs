using EarthMagicItems.Ammo.Bolts;
using EarthMagicItems.Ammo.Arrows;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthMagicItems
{
    /// <summary>
    /// Holds all items
    /// </summary>
    public static class ItemRegistry
    {
        public static GenericArrowStorage Arrows = new GenericArrowStorage();
        public static GenericBoltStorage Bolts = new GenericBoltStorage();
    }
}
