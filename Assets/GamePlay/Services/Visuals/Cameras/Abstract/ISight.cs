using UnityEngine;

namespace GamePlay.Services.Cameras.Abstract
{
    public interface ISight
    {
        bool IsOversight { get; }

        Vector3 CreateOversightMove();
    }
}