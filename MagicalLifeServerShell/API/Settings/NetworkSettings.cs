using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServerShell.API.Settings
{
    public class NetworkSettings
    {
        /// <summary>
        /// The port to host the server on.
        /// </summary>
        public int Port { get; set; }

        public NetworkSettings(bool setDefault)
        {
            this.Port = 58902;
        }

        public NetworkSettings()
        {

        }
    }
}
