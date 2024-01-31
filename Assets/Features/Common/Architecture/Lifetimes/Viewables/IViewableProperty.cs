using System;

namespace Common.Architecture.Lifetimes.Viewables
{
    public interface IViewableProperty<T>
    {
        T Value { get; }

        void View(ILifetime lifetime, Action<T> listener);
    }
}