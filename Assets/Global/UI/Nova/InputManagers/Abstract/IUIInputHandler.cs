using UnityEngine;

namespace Global.UI.Nova.InputManagers.Abstract
{
    public interface IUIInputHandler
    {
        void SetCamera(Camera camera);
        void RemoveCamera(Camera camera);
        bool IsCollidingLayer(int layerMask);
    }
}