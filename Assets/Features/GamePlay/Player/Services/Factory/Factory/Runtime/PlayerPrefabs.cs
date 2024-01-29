using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Services.Factory.Factory.Runtime
{
    [Serializable]
    public class PlayerPrefabs
    {
        [SerializeField] [Indent] private GameObject _local;
        [SerializeField] [Indent] private GameObject _remote;

        public GameObject Local => _local;
        public GameObject Remote => _remote;
    }
}