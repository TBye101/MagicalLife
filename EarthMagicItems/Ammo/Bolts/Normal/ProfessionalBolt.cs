namespace EarthMagicItems.Ammo.Bolts.Normal
{
    using EarthMagicItems.Ammo.Arrows;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    internal class ProfessionalBolt : GenericAmmo
    {
        public ProfessionalBolt()
            : base(new Die(1, 3, 0), "Professional Bolt", new Damage(new Die(1, 6, 0), DamageType.Piercing), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.ProfessionalBolt.md", .15)
        {
        }
    }
}