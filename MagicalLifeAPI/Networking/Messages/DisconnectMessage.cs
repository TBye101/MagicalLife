using MagicalLifeAPI.Networking.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking.Messages
{
    /// <summary>
    /// Used by the API to tell the server that a specific client has disconnected.
    /// </summary>
    public class DisconnectMessage : BaseMessage
    {
        public Guid ClientPlayerID { get; set; }

        /// <param name="playerID">The ID of the player client that is disconnecting.</param>
        public DisconnectMessage(Guid playerID) : base(9)
        {
            this.ClientPlayerID = playerID;
        }
    }
}
