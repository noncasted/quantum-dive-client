using Common.Tools.ObjectsPools.Runtime.Abstract;
using GamePlay.Services.Visuals.VfxPools.Abstract;
using UnityEngine;

namespace GamePlay.VfxPools.Runtime
{
    public class VfxPool : IVfxPool
    {
        public VfxPool(IPoolProvider pools)
        {
            _pools = pools;
        }

        private readonly IPoolProvider _pools;

        public IObjectProvider<T> GetPool<T>(T prefab) where T : MonoBehaviour
        {
            return _pools.GetPool(prefab);
        }

        public IObjectProvider<T> GetPool<T>(string key)
        {
            return _pools.GetPool<T>(key);
        }
    }
}