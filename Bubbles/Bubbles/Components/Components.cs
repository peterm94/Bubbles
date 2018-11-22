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

    public class RotateTowards : Component
    {
        public Entity Towards { get; set; }
    }

    public class Weapon : Component
    {
    }

    public class Destroyed : Component
    {
    }

    // Mark an entity with this to ignore destroy() calls on it.
    public class WontDestroy : Component
    {
    }

    public class FlashWhite : Component
    {
    }
}
