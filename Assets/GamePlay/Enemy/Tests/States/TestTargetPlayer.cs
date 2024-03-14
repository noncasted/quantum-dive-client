using GamePlay.Services.Combat.Targets.Registry.Abstract;
using UnityEngine;

namespace GamePlay.Enemy.Tests.States
{
    public class TestTargetPlayer : MonoBehaviour, ITargetPosition
    {
        public Vector3 Position => transform.position;
    }
}