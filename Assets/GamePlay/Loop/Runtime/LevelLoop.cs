using Cysharp.Threading.Tasks;
using GamePlay.Player.Services.Factory.Factory.Abstract;
using GamePlay.Services.Cameras.Abstract;
using Internal.Scopes.Abstract.Instances.Services;

namespace GamePlay.Loop.Runtime
{
    public class LevelLoop : IScopeLoadListener
    {
        public LevelLoop(IPlayerFactory factory, ILevelCamera levelCamera)
        {
            _factory = factory;
            _levelCamera = levelCamera;
        }

        private readonly IPlayerFactory _factory;
        private readonly ILevelCamera _levelCamera;

        public void OnLoaded()
        {
            Begin().Forget();
        }

        private async UniTask Begin()
        {
            var player = await _factory.Create();
            player.Respawn();
            _levelCamera.StartFollow(player.FollowTarget);
        }
    }
}