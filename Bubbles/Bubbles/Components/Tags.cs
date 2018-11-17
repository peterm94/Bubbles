using Nez;

namespace Bubbles.Components
{
    public class Player : Component
    {
    }

    public class PlayerControlled : Component
    {
    }

    public class Cursor : Component
    {
    }

    public class Enemy : Component
    {
    }

    public class RotateTowardsMouse : Component
    {
    }

    public class Weapon : Component
    {
    }

    public class Attacked : Component
    {
        public Attacked(Collider hitter)
        {
            Hitter = hitter;
        }

        public Collider Hitter { get; }
    }
}