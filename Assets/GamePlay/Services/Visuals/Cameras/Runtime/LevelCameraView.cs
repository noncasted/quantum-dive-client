using UnityEngine;

namespace GamePlay.Cameras.Runtime
{
    [RequireComponent(typeof(Camera))]
    [DisallowMultipleComponent]
    public class LevelCameraView : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        public Camera Camera => _camera;
    }
}