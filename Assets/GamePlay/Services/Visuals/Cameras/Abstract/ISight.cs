using UnityEngine;

namespace GamePlay.Visuals.Cameras.Abstract
{
    public interface ISight
    {
        bool IsOversight { get; }

        Vector3 CreateOversightMove();
    }
}