﻿using Global.UI.LoadingScreens.Logs;
using UnityEngine;
using VContainer;

namespace Global.UI.LoadingScreens.Runtime
{
    [DisallowMultipleComponent]
    public class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        [Inject]
        private void Construct(LoadingScreenLogger logger)
        {
            _logger = logger;
        }

        [SerializeField] private GameObject _canvas;
        [SerializeField] private GameObject _gameLoad; 
        
        private LoadingScreenLogger _logger;

        private void Awake()
        {
            _canvas.SetActive(false);
        }

        public void HideGameLoading()
        {
            _gameLoad.SetActive(false);
        }

        public void Show()
        {
            _canvas.SetActive(true);

            _logger.OnShown();
        }

        public void Hide()
        {
            _canvas.SetActive(false);

            _logger.OnHidden();
        }
    }
}