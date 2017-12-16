namespace EarthMagicItems.Ammo.Arrows.Normal
{
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// A +2 arrow item.
    /// </summary>
    public class _2Arrow : GenericAmmo
    {
        public _2Arrow()
            : base(new Die(3, 5, 0), "+2 Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 2)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+2Arrow.md", .2)
        {
        }
    }
}
