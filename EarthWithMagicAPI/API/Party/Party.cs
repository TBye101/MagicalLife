using EarthWithMagicAPI.API.Creature;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Party
{
    /// <summary>
    /// The party that the main character is traveling with. This includes the main character.
    /// </summary>
    public static class Party
    {
        public static List<ICreature> TheParty = new List<ICreature>();
    }
}
