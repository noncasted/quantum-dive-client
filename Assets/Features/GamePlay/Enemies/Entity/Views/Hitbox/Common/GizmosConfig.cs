using System;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Hitbox.Common
{
    [Serializable]
    public class GizmosConfig : IGizmosConfig
    {
        [SerializeField] [Min(0f)] private float _width;
        [SerializeField] private Color _color;

        public float Width => _width;
        public Color Color => _color;
    }
}