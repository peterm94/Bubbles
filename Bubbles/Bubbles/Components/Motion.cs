using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Components
{
    public class Motion : Component
    {
        public float Friction { get; } = 550f;

        /// <summary>
        ///     Speed. Should always be a positive number. If you want to go backwards, change the Direction vector.
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Direction to move in.
        /// TODO instead of changing this directly, we should apply a force to preserve momentum.
        /// </summary>
        public Vector2 Direction { get; set; }
    }
}
