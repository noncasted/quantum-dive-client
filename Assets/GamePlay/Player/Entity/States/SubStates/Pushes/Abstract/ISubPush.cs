using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Pushes.Abstract
{
    public interface ISubPush
    {
        UniTask PushAsync(Vector2 direction, PushParams parameters, CancellationToken cancellation);
    }
}