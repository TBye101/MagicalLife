namespace EarthMagicItems.Ammo.Arrows.Special
{
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// A basic frost arrow.
    /// </summary>
    public class FrostArrow : GenericAmmo
    {
        public FrostArrow()
            : base(new Die(1, 3, 0), "Frost Arrow", new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ColdArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.FrostArrow.md", .2)
        {
        }
    }
}