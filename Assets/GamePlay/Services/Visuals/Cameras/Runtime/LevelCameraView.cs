using UnityEngine;

namespace GamePlay.Services.Cameras.Runtime
{
    [RequireComponent(typeof(Camera))]
    [DisallowMultipleComponent]
    public class LevelCameraView : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        public Camera Camera => _camera;
    }
}