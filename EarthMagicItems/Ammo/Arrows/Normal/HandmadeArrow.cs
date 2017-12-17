namespace EarthMagicItems.Ammo.Arrows.Normal
{
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// A very crudely made arrow.
    /// </summary>
    public class HandmadeArrow : GenericAmmo
    {
        public HandmadeArrow()
            : base(new Die(1, 2, 0), "Handmade Arrow", new Damage(new Die(1, 6, 0), DamageType.Piercing), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.HandMadeArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.HandMadeArrow.md", .3)
        {
        }
    }
}