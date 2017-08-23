using EarthMagicItems.Ammo.Arrows;
using EarthMagicItems.Ammo.Bolts;
using EarthMagicItems.Ammo.Stones;
using EarthMagicItems.Armor.Generic.Steel;
using EarthMagicItems.Gems;

namespace EarthMagicItems
{
    /// <summary>
    /// Holds all items
    /// </summary>
    public static class ItemReg
    {
        //Armor
        public static GenericArmorStorage Armor = new GenericArmorStorage();

        //Ammo
        public static GenericArrowStorage Arrows = new GenericArrowStorage();

        public static GenericBoltStorage Bolts = new GenericBoltStorage();

        //Gems
        public static GenericGemStorage Gems = new GenericGemStorage();

        //Stones
        public static GenericStoneStorage Stones = new GenericStoneStorage();
    }
}