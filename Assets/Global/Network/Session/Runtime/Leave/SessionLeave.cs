using Cysharp.Threading.Tasks;
using Global.Network.Session.Abstract;

namespace Global.Network.Session.Runtime.Leave
{
    public class SessionLeave : ISessionLeave
    {
        public UniTask Leave()
        {
            return new UniTask();
        }
    }
}