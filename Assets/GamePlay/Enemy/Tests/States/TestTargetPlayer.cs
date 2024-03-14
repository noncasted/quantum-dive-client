using GamePlay.Targets.Registry.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Tests.States
{
    public class TestTargetPlayer : MonoBehaviour, ITargetPosition
    {
        public Vector3 Position => transform.position;
    }
}