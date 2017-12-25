namespace EarthMagicItems.Ammo.Arrows.Special
{
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// A basic fire arrow.
    /// </summary>
    public class FireArrow : GenericAmmo
    {
        public FireArrow()
            : base(new Die(1, 3, 0), "Fire Arrow", new Damage(Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.FireArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.FireArrow.md", .25)
        {
            this.Usability.CanFighter = true;
            this.Usability.CanMarksman = true;
            this.Usability.CanThief = true;
            this.Usability.CanRanger = true;
        }
    }
}