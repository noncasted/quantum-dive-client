using System;

namespace Common.Architecture.Lifetimes.Viewables
{
    public interface IViewableDelegate
    {
        void Invoke();
        void Listen(ILifetime lifetime, Action listener);
    }
    
    public interface IViewableDelegate<T>
    {
        void Invoke(T value);
        void Listen(ILifetime lifetime, Action<T> listener);
    }
    
    public interface IViewableDelegate<T1, T2>
    {
        void Invoke(T1 value1, T2 value2);
        void Listen(ILifetime lifetime, Action<T1, T2> listener);
    }
    
    public interface IViewableDelegate<T1, T2, T3>
    {
        void Invoke(T1 value1, T2 value2, T3 value3);
        void Listen(ILifetime lifetime, Action<T1, T2, T3> listener);
    }
}