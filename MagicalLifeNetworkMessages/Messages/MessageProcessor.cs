using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeNetworkMessages.Messages
{
    /// <summary>
    /// Holds various rules that process network messages.
    /// </summary>
    public class MessageProcessor
    {
        public List<IMessageHandler> Rules { get; private set; } = new List<IMessageHandler>();

        public void AddRule(IMessageHandler rule)
        {
            this.Rules.Add(rule);
        }

        public void RemoveRule(IMessageHandler rule)
        {
            this.Rules.Remove(rule);
        }

        /// <summary>
        /// Determines who can process a message, then hands the message off to anyone who can.
        /// </summary>
        /// <param name="message"></param>
        public void ProcessMessage(NetworkMessage message)
        {
            foreach (IMessageHandler item in this.Rules)
            {
                if (item.CanIHandle(message))
                {
                    item.HandleMessage(message);
                    break;
                }
            }
        }
    }
}
