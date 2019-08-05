using MLAPI.Networking;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Serialization;
using MLAPI.Networking.World;

namespace MLClient.Message_Handlers
{
    public class WorldTransferHeaderMessageHandler : MessageHandler
    {
        public WorldTransferHeaderMessageHandler() : base(NetMessageId.WorldTransferHeaderMessage)
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