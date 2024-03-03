using Cysharp.Threading.Tasks;
using GamePlay.Combat.Targets.Registry.Runtime;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Local
{
    public interface IMeleeAttack
    {
        UniTask Attack(ISearchableTarget target);
    }
}