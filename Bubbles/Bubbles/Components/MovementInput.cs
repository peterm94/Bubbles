using System;
using Nez;

namespace Bubbles.Components
{
    public class MovementInput : Component
    {
        public bool MoveUp { get; set; }
        public bool MoveDown { get; set; }
        public bool MoveLeft { get; set; }
        public bool MoveRight { get; set; }

        public void Clear()
        {
            MoveUp = false;
            MoveDown = false;
            MoveLeft = false;
            MoveRight = false;
        }

        public bool AnyMove()
        {
            return MoveUp || MoveDown || MoveLeft || MoveRight;
        }
    }
}
