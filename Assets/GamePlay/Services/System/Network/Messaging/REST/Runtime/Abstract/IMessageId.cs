using System;

namespace GamePlay.System.Network.Messaging.REST.Runtime.Abstract
{
    public interface IMessageId
    {
        Guid Value { get; }

        void SetValue(Guid value);
    }
}