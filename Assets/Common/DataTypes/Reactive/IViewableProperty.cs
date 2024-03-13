using System;
using Internal.Scopes.Abstract.Lifetimes;

namespace Common.DataTypes.Reactive
{
    public interface IViewableProperty<T>
    {
        T Value { get; }

        void View(ILifetime lifetime, Action<T> listener);
    }
}