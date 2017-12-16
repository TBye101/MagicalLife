// <copyright file="GenericArrowStorage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicItems.Ammo.Arrows
{
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// Storage for the generic arrows.
    /// </summary>
    public class GenericArrowStorage
    {
        #region NormalArrows

        private GenericAmmo _1Arrow = new GenericAmmo(new Die(2, 4, 0), "+1 Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 1)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+1Arrow.md", .2);

        private GenericAmmo _2Arrow = new GenericAmmo(new Die(3, 5, 0), "+2 Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 2)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+2Arrow.md", .2);

        private GenericAmmo _3Arrow = new GenericAmmo(new Die(4, 6, 0), "+3 Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 3)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+3Arrow.md", .2);

        private GenericAmmo _4Arrow = new GenericAmmo(new Die(5, 7, 0), "+4 Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 4)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+4Arrow.md", .2);

        private GenericAmmo _5Arrow = new GenericAmmo(new Die(6, 7, 0), "+5 Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 5)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+5Arrow.md", .2);

        private GenericAmmo ProfessionalArrow = new GenericAmmo(new Die(1, 3, 0), "Professional Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 0)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.ProfessionalArrow.md", .2);

        #endregion NormalArrows
    }
}