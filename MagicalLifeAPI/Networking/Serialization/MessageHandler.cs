namespace MagicalLifeAPI.Networking.Serialization
{
    /// <summary>
    /// Used to handle messages that are sent over the network.
    /// </summary>
    public abstract class MessageHandler
    {
        /// <summary>
        /// The ID of the <see cref="BaseMessage"/> that this handler knows what to do with.
        /// </summary>
        public NetMessageID MessageID { get; protected set; }

        public MessageHandler(NetMessageID ID)
        {
            this.MessageID = ID;
        }

        /// <summary>
        /// Implementers of this message must do something with the information that the message was passing along.
        /// </summary>
        /// <param name="message"></param>
        public abstract void HandleMessage(BaseMessage message);
    }
}