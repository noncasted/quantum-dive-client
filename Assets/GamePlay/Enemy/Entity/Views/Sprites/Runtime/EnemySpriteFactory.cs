using System;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;
using UnityEngine.Rendering;

namespace GamePlay.Enemy.Entity.Views.Sprites.Runtime
{
    [Serializable]
    public class EnemySpriteFactory : IComponentFactory
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private SortingGroup _sortingGroup;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<EnemySprite>()
                .AsImplementedInterfaces()
                .WithParameter(_spriteRenderer)
                .WithParameter(_sortingGroup);
        }
    }
}