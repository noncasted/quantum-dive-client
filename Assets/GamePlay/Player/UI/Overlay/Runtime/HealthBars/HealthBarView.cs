using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Player.UI.Overlay.Runtime.HealthBars
{
    [DisallowMultipleComponent]
    public class HealthBarView : MonoBehaviour, IHealthBarView
    {
        [SerializeField] private Transform _cellsRoot;
        [SerializeField] private HealthBarCell _cellPrefab;

        private readonly List<HealthBarCell> _all = new();

        public void SetHealth(int current, int max)
        {
            CreateOnDemand(max);
            AlignAll();
            DestroyOnDemand(max);

            for (var i = 0; i < _all.Count; i++)
            {
                if (i < current)
                    _all[i].Fill();
                else
                    _all[i].Release();
            }
        }

        private void AlignAll()
        {
            var step = GetStep();
            for (var i = 0; i < _all.Count; i++)
            {
                var cellTransform = _all[i].transform;

                var position = new Vector2(i * step, 0f);

                if (i % 2 == 1)
                    position.y += step;

                cellTransform.localPosition = position;
            }
        }

        private float GetStep()
        {
            if (_all.Count == 0)
                return 0f;

            var cell = _all[0];

            var size = cell.GetComponent<RectTransform>().sizeDelta;
            var step = Mathf.Sqrt((size.x / 2) * (size.x / 2) + (size.y / 2) * (size.y / 2));

            return step;
        }
        private void CreateOnDemand(int max)
        {
            if (max <= _all.Count)
                return;

            var delta = max - _all.Count;

            for (var i = 0; i < delta; i++)
            {
                var cell = Instantiate(_cellPrefab, _cellsRoot);
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
                Destroy(cell.gameObject);
                _all.RemoveAt(0);
            }
        }
    }
}