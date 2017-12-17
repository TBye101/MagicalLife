namespace EarthMagicItems.Ammo.Arrows.Normal
{
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// A +4 arrow item.
    /// </summary>
    public class _4Arrow : GenericAmmo
    {
        public _4Arrow()
            : base(new Die(5, 7, 0), "+4 Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 4)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+4Arrow.md", .2)
        {
        }
    }
}