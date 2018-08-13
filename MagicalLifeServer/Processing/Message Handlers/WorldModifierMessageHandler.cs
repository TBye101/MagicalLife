using MagicalLifeAPI.Networking;
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
        public WorldModifierMessageHandler() : base(NetMessageID.WorldModifierMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            WorldModifierMessage msg = (WorldModifierMessage)message;

            ServerSendRecieve.SendAllExcept(msg, msg.PlayerID);
            msg.WorldModifier.ModifyWorld();
        }
    }
}
