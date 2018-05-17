using MagicalLifeAPI.Load;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer
{
    /// <summary>
    /// Commands some high level functions of a server.
    /// </summary>
    public static class Server
    {
        public static void Start()
        {
            Loader load = new Loader();
            string msg = "";
            load.LoadAll(ref msg, new List<System.Reflection.Assembly>()
            {
                Assembly.GetAssembly(typeof(Server))
            });
        }
    }
}
