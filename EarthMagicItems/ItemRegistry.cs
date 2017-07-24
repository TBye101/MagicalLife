using EarthMagicItems.Gems;
using EarthMagicItems.Armor.Generic.Steel;
using EarthMagicItems.Ammo.Stones;
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
        //Ammo
        public static GenericArrowStorage Arrows = new GenericArrowStorage();
        public static GenericBoltStorage Bolts = new GenericBoltStorage();
        public static GenericStoneStorage Stones = new GenericStoneStorage();


        //Armor
        public static GenericArmorStorage Armor = new GenericArmorStorage();

        //Gems
        public static GenericGemStorage Gems = new GenericGemStorage();
    }
}
