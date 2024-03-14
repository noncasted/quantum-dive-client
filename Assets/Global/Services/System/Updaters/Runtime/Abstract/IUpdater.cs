
using Internal.Scopes.Abstract.Lifetimes;

namespace Global.System.Updaters.Runtime.Abstract
{
    public interface IUpdater
    {
        void Add(IUpdatable updatable);
        void Add(ILifetime lifetime, IUpdatable updatable);
        void Remove(IUpdatable updatable);

        void Add(IPreUpdatable updatable);
        void Add(ILifetime lifetime, IPreUpdatable updatable);
        void Remove(IPreUpdatable updatable);

        void Add(IPreFixedUpdatable updatable);
        void Add(ILifetime lifetime, IPreFixedUpdatable updatable);
        void Remove(IPreFixedUpdatable updatable);

        void Add(IFixedUpdatable updatable);
        void Add(ILifetime lifetime, IFixedUpdatable updatable);
        void Remove(IFixedUpdatable updatable);

        void Add(IPostFixedUpdatable updatable);
        void Add(ILifetime lifetime, IPostFixedUpdatable updatable);
        void Remove(IPostFixedUpdatable updatable);
        
        void Add(IGizmosUpdatable updatable);
        void Add(ILifetime lifetime, IGizmosUpdatable updatable);
        void Remove(IGizmosUpdatable updatable);
    }
}