namespace EarthMagicItems.Ammo.Bolts.Normal
{
    using EarthMagicItems.Ammo.Arrows;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    public class _5Bolt : GenericAmmo
    {
        public _5Bolt()
            : base(new Die(6, 7, 0), "+5 Bolt", new Damage(new Die(1, 6, 5), DamageType.Piercing), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.+5Bolt.md", .15)
        {
        }
    }
}