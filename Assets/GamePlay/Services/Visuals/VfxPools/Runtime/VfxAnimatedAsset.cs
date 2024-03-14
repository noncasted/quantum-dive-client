﻿using Internal.Scopes.Abstract.Containers;
using Common.Tools.ObjectsPools.Runtime;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using Internal.Scopes.Abstract.Containers;
using GamePlay.Visuals.VfxPools.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Visuals.VfxPools.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = VfxPoolRoutes.AnimatedName,
        menuName = VfxPoolRoutes.AnimatedPath)]
    public class VfxAnimatedAsset : PoolEntryAsset
    {
        [SerializeField] [Indent] private VfxAnimatedObject _prefab;

        public override string Key => _prefab.name;
        public override string Name => _prefab.name;

        public override IObjectsPool Create(IServiceCollection services, Transform parent)
        {
            var factory = new VfxObjectFactory<VfxAnimatedObject>(_prefab, parent);
            var provider = new ObjectProvider<VfxAnimatedObject>(factory, StartupInstances, parent);

            return provider;
        }
    }
}