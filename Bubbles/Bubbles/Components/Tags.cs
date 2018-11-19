using System;
using System.Net;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

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
