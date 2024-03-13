using Global.Inputs.Utils.Runtime.Conversion;
using UnityEngine;

namespace Global.Inputs.Utils.Runtime.Projection
{
    public interface IInputProjection
    {
        float GetAngleFrom(Vector3 from);
        Vector3 GetDirectionFrom(Vector3 from);
    }
}