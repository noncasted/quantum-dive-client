using System;

namespace GamePlay.Services.System.Network.Messaging.REST.Abstract
{
    public interface IMessageId
    {
        Guid Value { get; }

        void SetValue(Guid value);
    }
}