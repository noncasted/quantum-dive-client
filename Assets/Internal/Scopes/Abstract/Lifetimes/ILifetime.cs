using Cysharp.Threading.Tasks;

namespace Internal.Scopes.Abstract.Lifetimes
{
    public interface ILifetime : IReadOnlyLifetime
    {
        void Terminate();
    }
}