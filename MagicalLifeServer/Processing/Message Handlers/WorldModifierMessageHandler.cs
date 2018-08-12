using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeAPI.Networking.World.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.Processing.Message_Handlers
{
    public class WorldModifierMessageHandler : MessageHandler
    {
        public WorldModifierMessageHandler() : base(10)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            WorldModifierMessage msg = (WorldModifierMessage)message;

            ServerSendRecieve.SendAll(msg);
            msg.WorldModifier.ModifyWorld();
        }
    }
}
