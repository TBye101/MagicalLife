using MagicalLifeAPI.Networking.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Registry.Network
{
    /// <summary>
    /// A registry of all <see cref="NComponent"/>s.
    /// </summary>
    public static class NetComponentManager
    {
        private static Dictionary<Guid, NComponent> NetComponents;
    }
}
