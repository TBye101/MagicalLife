namespace EarthMagicItems.Ammo.Arrows.Normal
{
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// A +2 arrow item.
    /// </summary>
    public class _2Arrow : GenericAmmo
    {
        public _2Arrow()
            : base(new Die(3, 5, 0), "+2 Arrow", new Damage(new Die(1, 8, 2), DamageType.Piercing), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+2Arrow.md", .2)
        {
            this.Usability.CanFighter = true;
            this.Usability.CanMarksman = true;
            this.Usability.CanThief = true;
            this.Usability.CanRanger = true;
        }
    }
}