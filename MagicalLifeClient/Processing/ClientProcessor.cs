using MagicalLifeClient.Processing.Rules;
using MagicalLifeNetworkMessages.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeClient.Processing
{
    /// <summary>
    /// Handles client side message processing.
    /// </summary>
    public static class ClientProcessor
    {
        private static MessageProcessor Processor = new MessageProcessor();

        public static void Initialize()
        {
            Processor.AddRule(new ClientWorldDataTransferRule());
        }
    }
}
