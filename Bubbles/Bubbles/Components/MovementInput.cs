using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Components
{
    public class MovementInput : Component
    {
        public Vector2 MoveVector { get; private set; }

        public void SetMove(Vector2 moveVector)
        {
            if (moveVector != Vector2.Zero)
            {
                Vector2.Normalize(ref moveVector, out var normalized);
                MoveVector = normalized;
            }
            else
            {
                Clear();
            }
        }

        public void Clear()
        {
            MoveVector = Vector2.Zero;
        }

        public bool AnyMove()
        {
            return MoveVector != Vector2.Zero;
        }
    }
}
