using UnityEngine;

namespace Global.Cameras.Utils.Runtime
{
    public interface ICameraUtils
    {
        Vector3 ScreenToWorld(Vector3 screen);
    }
}