using Common.Architecture.Entities.Common.DefaultCallbacks;
using Cysharp.Threading.Tasks;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Setup.Root.Abstract
{
    public interface IEnemyRoot
    {
        IEntityCallbacks Callbacks { get; }

        UniTask Enable(RagonEntity entity, Vector2 position);
        UniTask Disable();
    }
}