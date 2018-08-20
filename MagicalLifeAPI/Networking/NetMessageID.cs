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
        JobAssignedMessage = 5,
        LoginMessage = 6,
        JobCompletedMessage = 7,
        JobCreatedMessage = 8,
        DisconnectMessage = 9,
        WorldModifierMessage = 10,
        WorldTransferBodyMessage = 11,
        WorldTransferRegistryMessage = 12
    }
}