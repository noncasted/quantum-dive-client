using UnityEngine;

namespace GamePlay.Cameras.Abstract
{
    public interface ISight
    {
        bool IsOversight { get; }

        Vector3 CreateOversightMove();
    }
}