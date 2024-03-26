using System;
using System.Collections.Generic;
using Internal.Scopes.Abstract.Lifetimes;

namespace Common.DataTypes.Runtime.Reactive
{
    public class ViewableDelegate : IViewableDelegate
    {
        private readonly List<Action> _listeners = new();

        public void Invoke()
        {
            foreach (var listener in _listeners)
                listener?.Invoke();
        }

        public void Listen(IReadOnlyLifetime lifetime, Action listener)
        {
            _listeners.Add(listener);

            lifetime.ListenTerminate(RemoveListener);

            return;

            void RemoveListener()
            {
                _listeners.Remove(listener);
            }
        }
    }

    public class ViewableDelegate<T> : IViewableDelegate<T>
    {
        private readonly List<Action<T>> _listeners = new();

        public void Invoke(T value)
        {
            foreach (var listener in _listeners)
                listener?.Invoke(value);
        }

        public void Listen(IReadOnlyLifetime lifetime, Action<T> listener)
        {
            _listeners.Add(listener);

            lifetime.ListenTerminate(RemoveListener);
            return;

            void RemoveListener()
            {
                _listeners.Remove(listener);
            }
        }
    }

    public class ViewableDelegate<T1, T2> : IViewableDelegate<T1, T2>
    {
        private readonly List<Action<T1, T2>> _listeners = new();

        public void Invoke(T1 value1, T2 value2)
        {
            foreach (var listener in _listeners)
                listener?.Invoke(value1, value2);
        }

        public void Listen(IReadOnlyLifetime lifetime, Action<T1, T2> listener)
        {
            _listeners.Add(listener);

            lifetime.ListenTerminate(RemoveListener);

            return;

            void RemoveListener()
            {
                _listeners.Remove(listener);
            }
        }
    }

    public class ViewableDelegate<T1, T2, T3> : IViewableDelegate<T1, T2, T3>
    {
        private readonly List<Action<T1, T2, T3>> _listeners = new();

        public void Invoke(T1 value1, T2 value2, T3 value3)
        {
            foreach (var listener in _listeners)
                listener?.Invoke(value1, value2, value3);
        }

        public void Listen(IReadOnlyLifetime lifetime, Action<T1, T2, T3> listener)
        {
            _listeners.Add(listener);

            lifetime.ListenTerminate(RemoveListener);

            return;

            void RemoveListener()
            {
                _listeners.Remove(listener);
            }
        }
    }
}