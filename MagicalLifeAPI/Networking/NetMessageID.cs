using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking
{
    /// <summary>
    /// Used to make message IDs a little less like magic numbers.
    /// </summary>
    public enum NetMessageID
    {
        BaseMessage = 1,
        WorldTransferMessage = 2,
        RouteCreatedMessage = 3,
        ServerTickMessage = 4,
        JobAssignedMessage = 5,
        LoginMessage = 6,
        JobCompletedMessage = 7,
        JobCreatedMessage = 8,
        DisconnectMessage = 9,
        WorldModifierMessage = 10
    }
}
