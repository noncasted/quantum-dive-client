using UnityEngine;

namespace GamePlay.Services.Combat.Targets.Registry.Abstract
{
    public interface ISearchableTarget
    {
        Vector3 Position { get; }
    }
}