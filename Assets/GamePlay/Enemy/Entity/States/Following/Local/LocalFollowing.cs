using GamePlay.Enemy.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Entity.States.Following.Common;
using GamePlay.Enemy.Entity.Views.AIPaths;
using GamePlay.Enemy.Entity.Views.Animators.Abstract;
using GamePlay.Enemy.Entity.Views.Sprites.Abstract;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Abstract;
using GamePlay.Services.Combat.Targets.Registry.Abstract;
using Global.System.Updaters.Abstract;

namespace GamePlay.Enemy.Entity.States.Following.Local
{
    public class LocalFollowing : IEnemyLocalState, IFollowing, IUpdatable
    {
        public LocalFollowing(
            ILocalStateMachine stateMachine,
            IEnemyAnimator animator,
            IEnemyAiFollower follower,
            IEnemySpriteFlipper spriteFlipper,
            IEnemyTransform transform,
            IUpdater updater,
            FollowingDefinition definition)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _follower = follower;
            _spriteFlipper = spriteFlipper;
            _transform = transform;
            _updater = updater;
            _definition = definition;
        }

        private readonly ILocalStateMachine _stateMachine;
        private readonly IEnemyAnimator _animator;
        private readonly IEnemyAiFollower _follower;
        private readonly IEnemySpriteFlipper _spriteFlipper;
        private readonly IEnemyTransform _transform;
        private readonly IUpdater _updater;
        
        private readonly FollowingDefinition _definition;

        public EnemyStateDefinition Definition => _definition;
        
        public void Break()
        {
            _follower.Stop();
            _updater.Remove(this);
        }  

        public void Follow(ISearchableTarget target)
        {
            _stateMachine.Enter(this);
            
            _follower.Follow(target);
            _updater.Add(this);
        }

        public void OnUpdate(float delta)
        {
            var direction = _follower.NextPoint - _transform.Position;
            _spriteFlipper.FlipAlong(direction, false);
        }
    }
}