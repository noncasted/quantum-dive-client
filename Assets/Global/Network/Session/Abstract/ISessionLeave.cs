using Cysharp.Threading.Tasks;

namespace Global.Network.Session.Abstract
{
    public interface ISessionLeave
    {
        UniTask Leave();
    }
}