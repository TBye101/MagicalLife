namespace EarthMagicItems.Ammo.Arrows
{
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// A very simple and generic acid arrow.
    /// </summary>
    public class AcidArrow : GenericAmmo
    {
        public AcidArrow()
            : base(new Die(1, 3, 0), "Acid Arrow", new Damage(new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.PoisonAcidArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.AcidArrow.md", .22)
        {
            this.Usability.CanFighter = true;
            this.Usability.CanMarksman = true;
            this.Usability.CanThief = true;
            this.Usability.CanRanger = true;
        }
    }
}