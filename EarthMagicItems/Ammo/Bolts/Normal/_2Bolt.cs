namespace EarthMagicItems.Ammo.Bolts.Normal
{
    using EarthMagicItems.Ammo.Arrows;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    public class _2Bolt : GenericAmmo
    {
        public _2Bolt()
            : base(new Die(3, 5, 0), "+2 Bolt", new Damage(new Die(1, 6, 2), DamageType.Piercing), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.+2Bolt.md", .15)
        {
        }
    }
}