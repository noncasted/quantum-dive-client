using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.Views.Sprites.Logs;
using UnityEngine;
using UnityEngine.Rendering;

namespace GamePlay.Enemy.Entity.Views.Sprites.Runtime
{
    [Serializable]
    public class EnemySpriteFactory : IComponentFactory
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private SortingGroup _sortingGroup;
        [SerializeField] private SpriteLogSettings _logSettings;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<SpriteLogger>()
                .WithParameter(_logSettings);

            services.Register<EnemySprite>()
                .AsImplementedInterfaces()
                .WithParameter(_spriteRenderer)
                .WithParameter(_sortingGroup);
        }
    }
}