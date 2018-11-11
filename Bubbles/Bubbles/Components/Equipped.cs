using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Components
{           
    public class Equipped : Component
    {
        public Entity Wielder { get; set; }
        public Vector2 Offset { get; set; }
    }
}