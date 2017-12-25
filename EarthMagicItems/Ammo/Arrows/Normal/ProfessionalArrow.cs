namespace EarthMagicItems.Ammo.Arrows.Normal
{
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// A arrow made by a professional arrow maker.
    /// </summary>
    public class ProfessionalArrow : GenericAmmo
    {
        public ProfessionalArrow()
            : base(new Die(1, 3, 0), "Professional Arrow", new Damage(new Die(1, 8, 0), DamageType.Piercing), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.ProfessionalArrow.md", .2)
        {
            this.Usability.CanFighter = true;
            this.Usability.CanMarksman = true;
            this.Usability.CanThief = true;
            this.Usability.CanRanger = true;
        }
    }
}