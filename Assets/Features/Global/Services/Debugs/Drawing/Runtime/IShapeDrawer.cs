using UnityEngine;

namespace Global.Debugs.Drawing.Runtime
{
    public interface IShapeDrawer
    {
        void DrawCircle(Vector2 position, float radius);
        void DrawCircle(float duration, Vector2 position, float radius);
        void DrawCircle(Vector2 position, float radius, float width);
        void DrawCircle(float duration, Vector2 position, float radius, float width);
        void DrawCircle(Vector2 position, float radius, Color color);
        void DrawCircle(float duration, Vector2 position, float radius, Color color);
        void DrawCircle(Vector2 position, float radius, float width, Color color);
        void DrawCircle(float duration, Vector2 position, float radius, float width, Color color);
        
        void DrawLine(Vector2 start, Vector2 end);
        void DrawLine(float duration, Vector2 start, Vector2 end);
        void DrawLine(Vector2 start, Vector2 end, float width);
        void DrawLine(float duration, Vector2 start, Vector2 end, float width);
        void DrawLine(Vector2 start, Vector2 end, Color color);
        void DrawLine(float duration, Vector2 start, Vector2 end, Color color);
        void DrawLine(Vector2 start, Vector2 end, float width, Color color);
        void DrawLine(float duration, Vector2 start, Vector2 end, float width, Color color);
        
        void DrawRect(Vector2 center, Vector2 size, float width, float angle, Color color);
    }
}