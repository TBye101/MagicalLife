using EarthMagicItems.Ammo.Arrows;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthMagicItems.Ammo.Bolts.Normal
{
    public class HandmadeBolt : GenericAmmo
    {
        public HandmadeBolt()
            : base(new Die(1, 2, 0), "Handmade Bolt", AmmoUtil.StandardBolt(new Die(1, 4, 0)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.HandMadeBolt.md", .25)
        {
        }
    }
}
