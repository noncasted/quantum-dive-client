using Cysharp.Threading.Tasks;

namespace Global.Network.Session.Abstract
{
    public interface ISessionJoin
    {
        UniTask<SessionJoinResult> Join(string id);
        UniTask<SessionJoinResult> JoinRandom();
    }
}