using Cysharp.Threading.Tasks;

namespace Global.Network.Session.Abstract
{
    public interface ISessionCreate
    {
        UniTask<SessionCreateResult> Create(string roomId);
    }
}