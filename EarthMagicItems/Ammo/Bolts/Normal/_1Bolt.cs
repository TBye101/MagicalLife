namespace EarthMagicItems.Ammo.Bolts.Normal
{
    using EarthMagicItems.Ammo.Arrows;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    public class _1Bolt : GenericAmmo
    {
        public _1Bolt()
            : base(new Die(2, 4, 0), "+1 Bolt", new Damage(new Die(1, 6, 1), DamageType.Piercing), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.+1Bolt.md", .15)
        {
        }
    }
}