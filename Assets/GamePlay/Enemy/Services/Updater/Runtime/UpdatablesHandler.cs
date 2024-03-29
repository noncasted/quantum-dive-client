﻿using System.Collections.Generic;

namespace GamePlay.Enemy.Updater.Runtime
{
    public class UpdatablesHandler<T>
    {
        private readonly List<T> _addQueue = new();
        private readonly List<T> _list = new();

        private readonly List<T> _removeQueue = new();

        public IReadOnlyList<T> List => _list;
        public int Count => _list.Count;

        public void Add(T updatable)
        {
            _addQueue.Add(updatable);
        }

        public void Remove(T updatable)
        {
            _removeQueue.Add(updatable);
        }

        public void Fetch()
        {
            FetchAdd();
            FetchRemove();
        }

        private void FetchAdd()
        {
            _list.AddRange(_addQueue);
            _addQueue.Clear();
        }

        private void FetchRemove()
        {
            foreach (var removed in _removeQueue)
                _list.Remove(removed);

            _removeQueue.Clear();
        }
    }
}