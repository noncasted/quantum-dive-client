using GamePlay.Targets.Registry.Runtime;
using UnityEngine;

namespace GamePlay.Enemies.Tests.States
{
    public class TestTargetPlayer : MonoBehaviour, ITargetPosition
    {
        public Vector2 Position => transform.position;
    }
}