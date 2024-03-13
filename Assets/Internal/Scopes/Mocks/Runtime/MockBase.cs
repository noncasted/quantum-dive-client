using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Internal.Scopes.Mocks.Runtime
{
    [DisallowMultipleComponent]
    public abstract class MockBase : MonoBehaviour
    {
        public abstract UniTaskVoid Process();
    }
}