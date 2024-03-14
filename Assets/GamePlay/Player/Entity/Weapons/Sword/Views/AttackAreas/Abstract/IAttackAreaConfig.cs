using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Abstract
{
    public interface IAttackAreaConfig
    {
        ContactFilter2D Filter { get; }
        int BufferSize { get; }
    }
}