using UnityEngine;

namespace Common.Tools.ObjectsPools.Runtime.Abstract
{
    public interface IObjectProvider<out T>
    {
        T Get(Vector3 position);
    }
}