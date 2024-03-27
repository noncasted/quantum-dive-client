using System.Collections.Generic;
using GamePlay.Enemy.Entity.Components.Healths.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.HealthBars.Runtime
{
    public class HealthBar : IEntitySwitchLifetimeListener
    {
        public HealthBar(IHealth health, Transform cellsRoot, HealthBarCell cellPrefab)
        {
            _health = health;
            _cellsRoot = cellsRoot;
            _cellPrefab = cellPrefab;
        }

        private const float _step = 0.0663f;

        private readonly IHealth _health;
        private readonly Transform _cellsRoot;
        private readonly HealthBarCell _cellPrefab;

        private readonly List<HealthBarCell> _all = new();

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            //_health.HealthChanged.Listen(lifetime, OnChanged);
        }

        private void OnChanged(int current, int max)
        {
            CreateOnDemand(current);
            DestroyOnDemand(current);
            AlignAll();

            for (var i = 0; i < _all.Count; i++)
            {
                if (i < current)
                    _all[i].Show();
                else
                    _all[i].Hide();
            }
        }

        private void AlignAll()
        {
            var startX = _all.Count * _step / -2f;

            for (var i = 0; i < _all.Count; i++)
            {
                var transform = _all[i].transform;

                var position = new Vector2(startX + i * _step, 0f);

                if (i % 2 == 1)
                    position.y += _step;

                transform.localPosition = position;
            }
        }

        private void CreateOnDemand(int max)
        {
            if (max <= _all.Count)
                return;

            var delta = max - _all.Count;

            for (var i = 0; i < delta; i++)
            {
                var cell = Object.Instantiate(_cellPrefab, _cellsRoot);
                _all.Add(cell);
            }
        }

        private void DestroyOnDemand(int max)
        {
            if (max <= _all.Count)
                return;

            var delta = _all.Count - max;

            for (var i = 0; i < delta; i++)
            {
                var cell = _all[0];
                Object.Destroy(cell.gameObject);
                _all.RemoveAt(0);
            }
        }
    }
}