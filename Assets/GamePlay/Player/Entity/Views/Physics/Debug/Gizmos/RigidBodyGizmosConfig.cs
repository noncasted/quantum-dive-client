﻿using GamePlay.Player.Entity.Views.Physics.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Physics.Debug.Gizmos
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerPhysicsRoutes.GizmosConfigName,
        menuName = PlayerPhysicsRoutes.GizmosConfigPath)]
    public class RigidBodyGizmosConfig : ScriptableObject, IGizmosConfig
    {
        [SerializeField] private Color _color;
        [SerializeField] [Min(0f)] private float _width;

        public Color Color => _color;
        public float Width => _width;
    }
}