namespace EarthMagicItems.Ammo.Bolts.Special
{
    using EarthMagicItems.Ammo.Arrows;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    public class FireBolt : GenericAmmo
    {
        public FireBolt()
            : base(new Die(1, 3, 0), "Fire Bolt", new Damage(Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), new Die(1, 6, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.FireBolt.md", .15)
        {
        }
    }
}