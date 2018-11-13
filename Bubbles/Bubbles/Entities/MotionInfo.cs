using Microsoft.Xna.Framework;

namespace Bubbles.Entities
{
    public struct MotionInfo
    {
        public Vector2 Offset { get; private set; }
        public float Angle { get; private set; }

        public MotionInfo(Vector2 offset, float angle)
        {
            this.Offset = offset;
            this.Angle = angle;
        }
    }
}
