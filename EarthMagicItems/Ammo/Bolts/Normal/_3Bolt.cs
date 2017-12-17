namespace EarthMagicItems.Ammo.Bolts.Normal
{
    using EarthMagicItems.Ammo.Arrows;
    using EarthWithMagicAPI.API.Util;

    public class _3Bolt : GenericAmmo
    {
        public _3Bolt()
            : base(new Die(4, 6, 0), "+3 Bolt", AmmoUtil.StandardBolt(new Die(1, 6, 3)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.+3Bolt.md", .15)
        {
        }
    }
}