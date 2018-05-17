using MagicalLifeAPI.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeClient
{
    /// <summary>
    /// Controls some high level functions of the server.
    /// </summary>
    public static class Client
    {
        public static void Start()
        {
            MainPathFinder.Initialize();
        }
    }
}
