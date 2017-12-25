namespace EarthMagicItems.Ammo.Arrows.Normal
{
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// A +3 arrow item.
    /// </summary>
    public class _3Arrow : GenericAmmo
    {
        public _3Arrow()
            : base(new Die(4, 6, 0), "+3 Arrow", new Damage(new Die(1, 8, 3), DamageType.Piercing), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+3Arrow.md", .2)
        {
            this.Usability.CanFighter = true;
            this.Usability.CanMarksman = true;
            this.Usability.CanThief = true;
            this.Usability.CanRanger = true;
        }
    }
}