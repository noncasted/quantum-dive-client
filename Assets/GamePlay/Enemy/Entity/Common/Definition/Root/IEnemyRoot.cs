using Cysharp.Threading.Tasks;
using Internal.Scopes.Common.Entity;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Common.Definition.Root
{
    public interface IEnemyRoot
    {
        IEntityCallbacks Callbacks { get; }

        UniTask Enable(RagonEntity entity, Vector2 position);
        UniTask Disable();
    }
}