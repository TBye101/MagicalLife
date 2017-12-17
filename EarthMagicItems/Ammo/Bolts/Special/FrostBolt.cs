namespace EarthMagicItems.Ammo.Bolts.Special
{
    using EarthMagicItems.Ammo.Arrows;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    internal class FrostBolt : GenericAmmo
    {
        public FrostBolt()
            : base(new Die(1, 3, 0), "Frost Bolt", new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), new Die(1, 6, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.FrostBolt.md", .15)
        {
        }
    }
}