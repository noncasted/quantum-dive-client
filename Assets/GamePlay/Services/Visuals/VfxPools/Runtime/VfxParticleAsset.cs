using Common.Tools.ObjectsPools.Runtime;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using GamePlay.VfxPools.Common;
using Internal.Scopes.Abstract.Containers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.VfxPools.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = VfxPoolRoutes.ParticleName,
        menuName = VfxPoolRoutes.ParticlePath)]
    public class VfxParticleAsset : PoolEntryAsset
    {
        [SerializeField] [Indent] private VfxParticleObject _prefab;

        public override string Key => _prefab.name;
        public override string Name => _prefab.name;

        public override IObjectsPool Create(IServiceCollection services, Transform parent)
        {
            var factory = new VfxObjectFactory<VfxParticleObject>(_prefab, parent);
            var provider = new ObjectProvider<VfxParticleObject>(factory, StartupInstances, parent);

            return provider;
        }
    }
}