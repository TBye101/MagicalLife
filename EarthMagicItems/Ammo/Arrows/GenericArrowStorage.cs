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
        private GenericAmmo _3Arrow = new GenericAmmo(new Die(4, 6, 0), "+3 Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 3)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+3Arrow.md", .2);

        private GenericAmmo _4Arrow = new GenericAmmo(new Die(5, 7, 0), "+4 Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 4)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+4Arrow.md", .2);

        private GenericAmmo _5Arrow = new GenericAmmo(new Die(6, 7, 0), "+5 Arrow", AmmoUtil.StandardArrow(new Die(1, 8, 5)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.ProfessionalArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.+5Arrow.md", .2);
    }
}