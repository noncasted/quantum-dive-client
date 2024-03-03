using System;

namespace GamePlay.Player.Entity.Components.Rotations.Orientation
{
    public static class OrientationUtils
    {
        public static PlayerOrientation ToOrientation(this float angle)
        {
            if (angle >= 0 && angle <= 22.5f)
                return PlayerOrientation.Side;

            if (angle > 22.5f && angle <= 67.5f)
                return PlayerOrientation.SideBack;

            if (angle > 67.5f && angle <= 112.5f)
                return PlayerOrientation.Up;

            if (angle > 112.5f && angle <= 157.5f)
                return PlayerOrientation.SideBack;

            if (angle > 157.5f && angle <= 202.5f)
                return PlayerOrientation.Side;

            if (angle > 202.5f && angle <= 247.5f)
                return PlayerOrientation.SideFace;

            if (angle > 247.5f && angle <= 292.5)
                return PlayerOrientation.Down;
            
            if (angle > 292.5f && angle <= 337.5f)
                return PlayerOrientation.SideFace;
            
            if (angle > 337.5f)
                return PlayerOrientation.Side;

            return PlayerOrientation.SideFace;
        }

        public static string ConvertToString(this PlayerOrientation orientation)
        {
            return orientation switch
            {
                PlayerOrientation.SideFace => "Side_Face",
                PlayerOrientation.SideBack => "Side_Back",
                PlayerOrientation.Up => "Up",
                PlayerOrientation.Down => "Down",
                PlayerOrientation.Side => "Side",
                _ => throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null)
            };
        }
    }
}