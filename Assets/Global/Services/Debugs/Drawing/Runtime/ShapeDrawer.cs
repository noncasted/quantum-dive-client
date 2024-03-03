using Drawing;
using Unity.Mathematics;
using UnityEngine;

namespace Global.Debugs.Drawing.Runtime
{
    public class ShapeDrawer : IShapeDrawer
    {
        private const float _defaultWidth = 10f;
        private readonly Color _defaultColor = Color.white;

        public void DrawCircle(Vector2 position, float radius)
        {
            DrawCircle(position, radius, _defaultWidth, _defaultColor);
        }

        public void DrawCircle(float duration, Vector2 position, float radius)
        {
            DrawCircle(duration, position, radius, _defaultWidth, _defaultColor);
        }

        public void DrawCircle(Vector2 position, float radius, float width)
        {
            DrawCircle(position, radius, width, _defaultColor);
        }

        public void DrawCircle(float duration, Vector2 position, float radius, float width)
        {
            DrawCircle(duration, position, radius, width, _defaultColor);

        }

        public void DrawCircle(Vector2 position, float radius, Color color)
        {
            DrawCircle(position, radius, _defaultWidth, color);
        }

        public void DrawCircle(float duration, Vector2 position, float radius, Color color)
        {
            DrawCircle(duration, position, radius, _defaultWidth, color);
        }

        public void DrawCircle(Vector2 position, float radius, float width, Color color)
        {
            using (Draw.WithLineWidth(width))
            {
                var resultPosition = new float3(position.x, position.y, 0f);

                Draw.CircleXY(resultPosition, radius, color);
            }
        }

        public void DrawCircle(float duration, Vector2 position, float radius, float width, Color color)
        {
            using (Draw.WithDuration(duration))
            {
                using (Draw.WithLineWidth(width))
                {
                    var resultPosition = new float3(position.x, position.y, 0f);

                    Draw.CircleXY(resultPosition, radius, color);
                }
            }
        }

        public void DrawLine(Vector2 start, Vector2 end)
        {
            DrawLine(start, end, _defaultWidth, _defaultColor);
        }

        public void DrawLine(float duration, Vector2 start, Vector2 end)
        {
            DrawLine(duration, start, end, _defaultWidth, _defaultColor);
        }

        public void DrawLine(Vector2 start, Vector2 end, float width)
        {
            DrawLine(start, end, width, _defaultColor);
        }

        public void DrawLine(float duration, Vector2 start, Vector2 end, float width)
        {
            DrawLine(duration, start, end, width, _defaultColor);
        }

        public void DrawLine(Vector2 start, Vector2 end, Color color)
        {
            DrawLine(start, end, _defaultWidth, color);
        }

        public void DrawLine(float duration, Vector2 start, Vector2 end, Color color)
        {
            DrawLine(duration, start, end, _defaultWidth, color);
        }

        public void DrawLine(Vector2 start, Vector2 end, float width, Color color)
        {
            using (Draw.WithLineWidth(width))
            {
                Draw.Line(start, end, color);
            }
        }

        public void DrawLine(float duration, Vector2 start, Vector2 end, float width, Color color)
        {
            using (Draw.WithDuration(duration))
            {
                using (Draw.WithLineWidth(width))
                {
                    Draw.Line(start, end, color);
                }
            }
        }

        public void DrawRect(Vector2 center, Vector2 size, float width, float angle, Color color)
        {
            using (Draw.WithLineWidth(width))
            {
                var convertedCenter = new float3(center.x, center.y, 0f);
                var convertedSize = new float2(center.x, center.y);
                var rotation = Quaternion.Euler(0f, 0f, angle);
                
                Draw.WireRectangle(convertedCenter, rotation, convertedSize, color);
            }
        }
    }
}