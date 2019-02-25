using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.World;
using MagicalLifeAPI.World.Data;

namespace MagicalLifeClient.Message
{
    public class WorldTransferHeaderMessageHandler : MessageHandler
    {
        public WorldTransferHeaderMessageHandler() : base(NetMessageID.WorldTransferHeaderMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            WorldTransferHeaderMessage msg = (WorldTransferHeaderMessage)message;
            NetWorldReceiver.Receive(msg);
            
            if (msg.DimensionHeaders.Count > 0)
            {
                //System.Guid aDimension = msg.DimensionHeaders[0].ID;
                //int index = World.Dimensions.FindIndex(x => x.ID.Equals(aDimension));

                //if (index != -1)
                //{
                    //World.RaiseChangeCameraDimension(0);
                //}
            }
        }
    }
}