﻿using System;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.VfxPools.Runtime
{
    [DisallowMultipleComponent]
    public class VfxParticleObject : MonoBehaviour, IPoolObject
    {
        [SerializeField] private ParticleSystem _particles;

        private Action<IPoolObject> _returnToPool;

        public GameObject GameObject => gameObject;

        public void Construct(Action<IPoolObject> returnToPool)
        {
            _returnToPool = returnToPool;
        }

        public void OnTaken()
        {
            OnReturned();

            Play().Forget();
        }

        public void OnReturned()
        {
            _particles.Stop();
        }

        private async UniTask Play()
        {
            await UniTask.WaitUntil(() => _particles.isPlaying == false);

            _returnToPool?.Invoke(this);
        }
    }
}