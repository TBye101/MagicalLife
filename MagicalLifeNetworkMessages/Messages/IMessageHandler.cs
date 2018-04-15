using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeNetworkMessages.Messages
{
    /// <summary>
    /// Classes that implement this are used to handle a specific message, and know what to do with the information recieved.
    /// </summary>
    public interface IMessageHandler
    {
        /// <summary>
        /// Do something with the information recieved.
        /// </summary>
        /// <param name="message"></param>
        void HandleMessage(NetworkMessage message);

        /// <summary>
        /// Determines if this message handler can handle the specified type of messages.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        bool CanIHandle(NetworkMessage message);
    }
}
