using EarthMagicItems.Ammo.Arrows;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthMagicItems.Ammo.Bolts.Normal
{
    class ProfessionalBolt : GenericAmmo
    {
        public ProfessionalBolt()
            : base(new Die(1, 3, 0), "Professional Bolt", AmmoUtil.StandardBolt(new Die(1, 6, 0)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.ProfessionalBolt.md", .15)
        {
        }
    }
}
