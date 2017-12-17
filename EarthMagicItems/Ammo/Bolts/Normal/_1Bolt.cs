using EarthMagicItems.Ammo.Arrows;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthMagicItems.Ammo.Bolts.Normal
{
    public class _1Bolt : GenericAmmo
    {
        public _1Bolt()
            : base(new Die(2, 4, 0), "+1 Bolt", AmmoUtil.StandardBolt(new Die(1, 6, 1)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.+1Bolt.md", .15)
        {
        }
    }
}
