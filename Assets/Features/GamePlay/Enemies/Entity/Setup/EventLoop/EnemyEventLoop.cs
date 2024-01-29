using System.Collections.Generic;
using Common.Architecture.Container.Abstract;

namespace GamePlay.Enemies.Entity.Setup.EventLoop
{
    public class EnemyEventLoop : ICallbackRegister, IEnemyEventLoop
    {
        private readonly List<IEnemyAwakeListener> _awakes = new();
        private readonly List<IEnemySwitchListener> _switches = new();
        private readonly List<IEnemyAttachListener> _attaches = new();

        public void Listen(object listener)
        {
            TryAddToList(_awakes, listener);
            TryAddToList(_switches, listener);
            TryAddToList(_attaches, listener);
        }

        public void InvokeAwake()
        {
            foreach (var callback in _awakes)
                callback.OnAwake();
        }

        public void InvokeEnable()
        {
            foreach (var callback in _switches)
                callback.OnEnabled();
        }

        public void InvokeDisable()
        {
            foreach (var callback in _switches)
                callback.OnDisabled();
        }

        public void InvokeEntityAttached()
        {
            foreach (var callback in _attaches)
                callback.OnEntityAttached();
        }

        private void TryAddToList<T1, T2>(ICollection<T1> list, T2 component) where T1 : class
        {
            if (component is T1 callback)
                list.Add(callback);
        }
    }
}