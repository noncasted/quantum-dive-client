﻿using Cysharp.Threading.Tasks;
using Global.GameLoops.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

//using GamePlay.Common.Config.Runtime;
//using Menu.Config.Runtime;

namespace Global.GameLoops.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GameLoopRouter.ServiceName,
        menuName = GameLoopRouter.ServicePath)]
    public class GameLoopFactory : ScriptableObject, IServiceFactory
    {
        // [SerializeField] private MenuConfig _menuScope;
        // [SerializeField] private LevelConfig _levelScope;

        public virtual async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<GameLoop>()
                //.WithParameter(_levelScope)
                //.WithParameter(_menuScope)
                .WithParameter(utils.Data.Scope)
                .AsSelfResolvable()
                .AsCallbackListener();
        }
    }
}