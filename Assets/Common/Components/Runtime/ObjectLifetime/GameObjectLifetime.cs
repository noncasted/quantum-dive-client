using Common.Components.Abstract;
using Internal.Scopes.Abstract.Lifetimes;
using Internal.Scopes.Runtime.Lifetimes;
using UnityEngine;

namespace Common.Components.Runtime.ObjectLifetime
{
    [DisallowMultipleComponent]
    public class GameObjectLifetime : MonoBehaviour, IGameObjectLifetime
    {
        private ILifetime _lifetime;

        private void OnDisable()
        {
            _lifetime?.Terminate();
        }

        public IReadOnlyLifetime GetValidLifetime()
        {
            if (gameObject.activeInHierarchy == false)
            {
                if (_lifetime == null)
                    _lifetime = new TerminatedLifetime();

                return _lifetime;
            }

            _lifetime ??= new Lifetime();
            
            if (_lifetime.IsTerminated == false)
                return _lifetime;

            _lifetime = new Lifetime();

            return _lifetime;
        }
    }
}