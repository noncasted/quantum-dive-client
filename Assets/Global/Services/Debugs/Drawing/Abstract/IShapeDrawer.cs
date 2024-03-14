using UnityEngine;

namespace Global.Debugs.Drawing.Runtime
{
    public interface IShapeDrawer
    {
        void DrawCircle(Vector3 position, float radius);
        void DrawCircle(float duration, Vector3 position, float radius);
        void DrawCircle(Vector3 position, float radius, float width);
        void DrawCircle(float duration, Vector3 position, float radius, float width);
        void DrawCircle(Vector3 position, float radius, Color color);
        void DrawCircle(float duration, Vector3 position, float radius, Color color);
        void DrawCircle(Vector3 position, float radius, float width, Color color);
        void DrawCircle(float duration, Vector3 position, float radius, float width, Color color);
        
        void DrawLine(Vector3 start, Vector3 end);
        void DrawLine(float duration, Vector3 start, Vector3 end);
        void DrawLine(Vector3 start, Vector3 end, float width);
        void DrawLine(float duration, Vector3 start, Vector3 end, float width);
        void DrawLine(Vector3 start, Vector3 end, Color color);
        void DrawLine(float duration, Vector3 start, Vector3 end, Color color);
        void DrawLine(Vector3 start, Vector3 end, float width, Color color);
        void DrawLine(float duration, Vector3 start, Vector3 end, float width, Color color);
        
        void DrawRect(Vector3 center, Vector3 size, float width, float angle, Color color);
    }
}