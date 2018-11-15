using Microsoft.Xna.Framework;

namespace Bubbles.Entities
{
    public struct MotionInfo: Action
    {
        public Vector2 Offset { get; }
        public float Angle { get; }

        public MotionInfo(Vector2 offset, float angle)
        {
            Offset = offset;
            Angle = angle;
        }
    }
}
