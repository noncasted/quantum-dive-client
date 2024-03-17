using System;
using System.Collections.Generic;
using Internal.Scopes.Abstract.Lifetimes;

namespace Common.DataTypes.Reactive
{
    public class ViewableProperty<T> : IViewableProperty<T>
    {
        private readonly List<Action<T>> _listeners = new();
        private readonly List<Action> _emptyListeners = new();

        private T _value;

        public T Value => _value;

        public void Set(T value)
        {
            _value = value;
            
            Invoke(value);
        }
        
        public void View(ILifetime lifetime, Action<T> listener)
        {
            _listeners.Add(listener);

            listener.Invoke(_value);
            lifetime.ListenTerminate(RemoveListener);
            
            return;

            void RemoveListener()
            {
                _listeners.Remove(listener);
            }
        }

        public void View(ILifetime lifetime, Action listener)
        {
            _emptyListeners.Add(listener);

            listener.Invoke();
            lifetime.ListenTerminate(RemoveListener);
            
            return;

            void RemoveListener()
            {
                _emptyListeners.Remove(listener);
            }
        }

        private void Invoke(T value)
        {
            foreach (var listener in _listeners)
                listener?.Invoke(value);
            
            foreach (var listener in _emptyListeners)
                listener?.Invoke();
        }
    }
}