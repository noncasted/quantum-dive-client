namespace GamePlay.Services.System.Network.Messaging.REST.Abstract
{
    public interface IMessage
    {
        IMessageId RequestId { get; }
    }
}