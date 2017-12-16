namespace EarthMagicItems.Ammo.Arrows.Normal
{
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// A arrow made by a professional arrow maker.
    /// </summary>
    public class ProfessionalArrow : GenericAmmo
    {
        public ProfessionalArrow()
            : base(new Die(1, 3, 0), "Professional Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 0)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.ProfessionalArrow.md", .2)
        {
        }
    }
}
