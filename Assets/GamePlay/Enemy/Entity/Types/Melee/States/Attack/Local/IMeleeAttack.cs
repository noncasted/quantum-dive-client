using Cysharp.Threading.Tasks;
using GamePlay.Services.Combat.Targets.Registry.Abstract;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Local
{
    public interface IMeleeAttack
    {
        UniTask Attack(ISearchableTarget target);
    }
}