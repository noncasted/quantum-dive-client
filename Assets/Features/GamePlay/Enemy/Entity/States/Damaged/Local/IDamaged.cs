using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Damaged.Local
{
    public interface IDamaged
    {
        UniTask Enter(Vector2 damageDirection, float pushForce);
    }
}