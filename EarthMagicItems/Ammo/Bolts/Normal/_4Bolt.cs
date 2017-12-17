namespace EarthMagicItems.Ammo.Bolts.Normal
{
    using EarthMagicItems.Ammo.Arrows;
    using EarthWithMagicAPI.API.Util;

    public class _4Bolt : GenericAmmo
    {
        public _4Bolt()
            : base(new Die(5, 7, 0), "+4 Bolt", AmmoUtil.StandardBolt(new Die(1, 6, 4)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.+4Bolt.md", .15)
        {
        }
    }
}