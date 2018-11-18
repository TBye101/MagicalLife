namespace MagicalLifeAPI.Networking
{
    /// <summary>
    /// Used to make message IDs a little less like magic numbers.
    /// 0 is invalid in Protobuf-net, so it cannot be used here.
    /// </summary>
    public enum NetMessageID
    {
        BaseMessage = 1,
        WorldTransferHeaderMessage = 2,
        RouteCreatedMessage = 3,
        ServerTickMessage = 4,
        LoginMessage = 5,
        DisconnectMessage = 6,
        WorldModifierMessage = 7,
        WorldTransferBodyMessage = 8,
        WorldTransferRegistryMessage = 9
    }
}